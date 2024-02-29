using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using ReactiveUI;

namespace bank.ViewModels;

public class StoragePageViewModel : ViewModelBase
{
    private string _name;
    private int _count;
    private float _price;
    private Storage _selectedStorage;
    private  List<Storage> _storages = GlobalStorage.Instance.Storages;
    private bool _isSelectedStorage;

    private readonly IStorageService _storageService =
        new StorageService(new StorageRepository());

    private readonly IProductService _productService =
        new ProductService(new ProductRepository());

    private readonly ICompanyService _companyService =
        new CompanyService(new CompanyRepository());
    private  List<Company> _companies = GlobalStorage.Instance.Companies;
    private Product _selectedProduct;
    public ReactiveCommand<Unit, Unit> CreateProductCommand { get; }
    private  List<Product> _products = new ();
    private Company _companyProduct;

    public StoragePageViewModel()
    {
        CreateProductCommand = ReactiveCommand.Create(ExecuteCreateProductCommand, this.WhenAnyValue(
            x => x.Name,
            x => x.Count,
            x => x.Price,
            (name, count, price) =>
                !string.IsNullOrWhiteSpace(name)
                && int.IsPositive(count)
                && float.IsPositive(price)
        ));
        GlobalStorage.Instance.Storages =
            _storageService.GetAllStoragesByUserId(GlobalStorage.Instance.User.Id);
        GlobalStorage.Instance.Companies = _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
        Companies = GlobalStorage.Instance.Companies.OrderBy(c=>c.Name).ToList();
        Storages = GlobalStorage.Instance.Storages;
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

    public Company CompanyProduct
    {
        get => _companyProduct;
        set
        {
            _companyProduct = value;
            OnPropertyChanged(nameof(CompanyProduct));
        }
    }
    
    public Storage SelectedStorage
    {
        get => _selectedStorage;
        set
        {
            if (_selectedStorage != value)
            {
                _selectedStorage = value;
                OnPropertyChanged(nameof(SelectedStorage));
                IsSelectedStorage = _selectedStorage != null;
                if (_selectedStorage!=null)
                {
                      GlobalStorage.Instance.Products = _productService.GetAllProductsByStorageId(SelectedStorage.Id);
                      Products = GlobalStorage.Instance.Products;
                }
                GlobalStorage.Instance.SelectedStorage = _selectedStorage;
            }
        }
    }
    
    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            _selectedProduct = value;
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }

    public  List<Storage> Storages
    {
        get => _storages;
        set
        {
            _storages = value;
            OnPropertyChanged(nameof(Storages));
            _storages = GlobalStorage.Instance.Storages;
        }
    }

    public bool IsSelectedStorage
    {
        get => _isSelectedStorage;
        set
        {
            _isSelectedStorage = value;
            OnPropertyChanged(nameof(IsSelectedStorage));
        }
    }

    public void Back()
    {
        SelectedStorage = null;
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            OnPropertyChanged(nameof(Count));
        }
    }
    
    public float Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    private void ExecuteCreateProductCommand()
    {
        var product = new Product(Name, Count, Price);
        var storageProduct = new StorageProduct
        {
            StorageId = GlobalStorage.Instance.SelectedStorage.Id,
            ProductId = product.Id
        };
        product.StorageProducts.Add(storageProduct);
        var productCompany = new ProductCompany
        {
            ProductId = product.Id,
            CompanyId = CompanyProduct.Id
        };
        product.ProductCompanies.Add(productCompany);
        _productService.Add(product);
    }

}