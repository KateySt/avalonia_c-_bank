using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using ReactiveUI;

namespace bank.ViewModels;

public class HomePageViewModel : ViewModelBase
{
    private string _name;
    private string _password;
    private User _user;
    private readonly IUserService _userService = new UserService(new UserRepository());
    private  List<Product> _products = new ();
    private  List<Company> _companies = GlobalStorage.Instance.Companies;
    private readonly IProductService _productService =
        new ProductService(new ProductRepository());
    private readonly ITransactionService _transactionService = new TransactionService(new TransactionRepository());
    private readonly ICompanyService _companyService =
        new CompanyService(new CompanyRepository());
    private Company _company;
    private Product _product;
    public int _countProduct;
    private List<Transaction> _transactions;
    private DateTime _date = DateTime.Today;
    public ReactiveCommand<Unit, Unit> CreateTransactionCommand { get; }
    public HomePageViewModel()
    {
        CreateOrLoginCommand = ReactiveCommand.Create(CreateOrLoginUser, this.WhenAnyValue(
            x => x.Name,
            x => x.Password,
            (name,password) => !string.IsNullOrWhiteSpace(name) 
                                      && !string.IsNullOrWhiteSpace(password)));
        CreateTransactionCommand = ReactiveCommand.Create(CreateTransaction, this.WhenAnyValue(
            x => x.CountProduct,
            (count) => int.IsPositive(count) && count != 0));
        if (GlobalStorage.Instance.User != null)
        {
            GlobalStorage.Instance.Transactions =
                _transactionService.GetAllTransactionsByUserId(GlobalStorage.Instance.User.Id);
            Transactions = GlobalStorage.Instance.Transactions; 
        }
    }
    
    public int CountProduct
    {
        get => _countProduct;
        set
        {
            _countProduct = value;
            OnPropertyChanged(nameof(CountProduct));
        }
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    public Company Company
    {
        get => _company;
        set
        {
            if (_company != value)
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
                if (Company != null && Product == null)
                {
                    Products = _productService.GetAllProductsByUserIdAndCompanyId(GlobalStorage.Instance.User.Id,
                        Company.Id);
                }
            }
        }
    }
    
    public Product Product
    {
        get => _product;
        set
        {
            if (_product != value)
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
                if (Product != null && Company == null)
                {
                    Companies = _companyService.GetAllCompaniesByUserIdAndProductId(GlobalStorage.Instance.User.Id,
                        Product.Id);
                }
            }
        }
    }
    
    public  List<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged(nameof(Products));
        }
    }
    
    public  List<Transaction> Transactions
    {
        get => _transactions;
        set
        {
           _transactions = value;
            OnPropertyChanged(nameof(Transactions));
        }
    }
    
    public  List<Company> Companies
    {
        get => _companies;
        set
        {
            _companies = value;
            OnPropertyChanged(nameof(Companies));
            _companies = GlobalStorage.Instance.Companies;
        }
    }
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name));}
    }

    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(nameof(Password)); }
    }

    public User User
    {
        get => _user;
        set   { 
            _user = value; 
            OnPropertyChanged(nameof(User)); 
            GlobalStorage.Instance.User = _user;
            GlobalStorage.Instance.IsUserEmpty = _user != null;
        }
    }
    
    public ReactiveCommand<Unit, Unit> CreateOrLoginCommand { get; }

    private void CreateOrLoginUser()
    {
        var newUser = new User { Name = Name, Password = Password };
        User = _userService.CreateOrFindUser(newUser);
        GlobalStorage.Instance.Companies = _companyService.GetAllCompaniesByUserId(User.Id);
        Companies = GlobalStorage.Instance.Companies.OrderBy(c=>c.Name).ToList();
        GlobalStorage.Instance.Products = _productService.GetAllProductsByUserId(User.Id);
        Products = GlobalStorage.Instance.Products.OrderBy(c=>c.Name).ToList();
        GlobalStorage.Instance.Transactions =
            _transactionService.GetAllTransactionsByUserId(GlobalStorage.Instance.User.Id);
        Transactions = GlobalStorage.Instance.Transactions;
    }
    
    private void CreateTransaction()
    {
        var transaction = new Transaction(CountProduct, Date); 
        var transactionProduct = new TransactionProduct
        {
            TransactionId = transaction.Id,
            ProductId = Product.Id
        };
        transaction.TransactionProducts.Add(transactionProduct);
        var transactionCompany = new TransactionCompany
        {
            TransactionId = transaction.Id,
            CompanyId = Company.Id
        };
        transaction.TransactionCompanies.Add(transactionCompany);
        _transactionService.Add(transaction);
    }
}