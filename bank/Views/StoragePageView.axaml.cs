using System.Linq;
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

    public StoragePageView()
    {
        InitializeComponent();
        modalProduct.IsVisible = false;
    }

    private void ShowModalProduct(object? sender, RoutedEventArgs e)
    {
        modalProduct.IsVisible = !modalProduct.IsVisible;
        nameProduct.Text = "";
        countProduct.Text = "0";
        priceProduct.Text = "0";
    }

    private void ChangeModalProduct(object? sender, EffectiveViewportChangedEventArgs e)
    {
        storages.ItemsSource = _storageService.GetAllStoragesByUserId(GlobalStorage.Instance.User.Id);
        GlobalStorage.Instance.Storages = 
            _storageService.GetAllStoragesByUserId(GlobalStorage.Instance.User.Id);
    }

    private void ClickHandlerProduct(object? sender, RoutedEventArgs e)
    {
        modalProduct.IsVisible = !modalProduct.IsVisible;
    }
}