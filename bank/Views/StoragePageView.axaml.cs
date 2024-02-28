using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using bank.Context;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using bank.ViewModels;

namespace bank.Views;

public partial class StoragePageView : UserControl
{
    private readonly IStorageService _storageService =
        new StorageService(new StorageRepository());
    private readonly IProductService _productService =
        new ProductService(new ProductRepository());
    public StoragePageView()
    {
        InitializeComponent();
        modalProduct.IsVisible = false;
        ComboBox.SelectedIndex = 0;
       
    }

    private void ShowModalProduct(object? sender, RoutedEventArgs e)
    {
        modalProduct.IsVisible = !modalProduct.IsVisible;
        nameProduct.Text = "";
        countProduct.Text = "0";
        priceProduct.Text = "0";
        ComboBox.SelectedIndex = 0; 
    }

    private void ChangeModalProduct(object? sender, EffectiveViewportChangedEventArgs e)
    {
     
    }

    private void ClickHandlerProduct(object? sender, RoutedEventArgs e)
    {
        modalProduct.IsVisible = !modalProduct.IsVisible;
        if (GlobalStorage.Instance.SelectedStorage!=null)
        {
            productDataGrid.ItemsSource =
                        _productService.GetAllProductsByStorageId(GlobalStorage.Instance.SelectedStorage.Id);
        }
    }
}