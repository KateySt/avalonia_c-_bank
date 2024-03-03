using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
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
        ModalProduct.IsVisible = false;
        ComboBox.SelectedIndex = 0;
    }

    private void ShowModalProduct(object? sender, RoutedEventArgs e)
    {
        ModalProduct.IsVisible = !ModalProduct.IsVisible;
        NameProduct.Text = "";
        CountProduct.Text = "0";
        PriceProduct.Text = "0";
        ComboBox.SelectedIndex = 0; 
    }

    private void ChangeModalProduct(object? sender, EffectiveViewportChangedEventArgs e)
    {
        if (GlobalStorage.Instance.SelectedStorage!=null)
        {
            ProductDataGrid.ItemsSource =
                _productService.GetAllProductsByStorageId(GlobalStorage.Instance.SelectedStorage.Id);
        }
    }

    private void ClickHandlerProduct(object? sender, RoutedEventArgs e)
    {
        ModalProduct.IsVisible = !ModalProduct.IsVisible;
    }
}