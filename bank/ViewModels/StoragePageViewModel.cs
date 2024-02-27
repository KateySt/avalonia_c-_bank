using System.Collections.Generic;
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

    public ReactiveCommand<Unit, Unit> CreateProductCommand { get; }

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
            _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
        Storages = GlobalStorage.Instance.Storages;
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
                GlobalStorage.Instance.SelectedStorage = _selectedStorage;
            }
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
            CompanyId = GlobalStorage.Instance.SelectedCompany.Id
        };
        product.ProductCompanies.Add(productCompany);
        _productService.Add(product);
    }

}