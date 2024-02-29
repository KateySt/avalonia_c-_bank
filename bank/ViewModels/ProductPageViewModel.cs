using System.Collections.Generic;
using System.Collections.ObjectModel;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace bank.ViewModels;

public class ProductPageViewModel : ViewModelBase
{
    private string _name;
    private int _count;
    private float _price;
    private Product _selectedProduct;
    private bool _isSelectedProduct;
    private  List<Product> _products = new ();
    private readonly IProductService _productService = new ProductService(new ProductRepository());
    private readonly ObservableCollection<Product> _observableValues;
    public ObservableCollection<ISeries> Series { get; set; }
    public  List<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged(nameof(Products));
        }
    }
    
    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            _selectedProduct = value;
            OnPropertyChanged(nameof(SelectedProduct));
            Series.Clear();
            if (_selectedProduct != null)
            {
                Series.Add(new LineSeries<Product>
                {
                    Values = new List<Product> { _selectedProduct },
                    Mapping = (sample, index) => new((float)sample.Count, sample.Price)
                });
            }
            IsSelectedProduct = _selectedProduct != null;
        }
    }
    
    public bool IsSelectedProduct
    {
        get => _isSelectedProduct;
        set
        {
            _isSelectedProduct = value;
            OnPropertyChanged(nameof(IsSelectedProduct));
        }
    }
    public void Back()
    {
        SelectedProduct = null;
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
    
    public ProductPageViewModel()
    {
        GlobalStorage.Instance.Products = _productService.GetAllProductsByUserId(GlobalStorage.Instance.User.Id);
        Products = GlobalStorage.Instance.Products;
        
        _observableValues = new ObservableCollection<Product>(GlobalStorage.Instance.Products);

        Series = new ObservableCollection<ISeries>
        {
            new LineSeries<Product>
            {
                Values = _observableValues,
                Mapping = (sample, index) => new(0, 0)
            }
        };
    }
}