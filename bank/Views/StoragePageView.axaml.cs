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

    public StoragePageView()
    {
        InitializeComponent();
    }

    private void ShowModal(object? sender, RoutedEventArgs e)
    {
        modal.IsVisible = !modal.IsVisible;
        name.Text = "";
        count.Text = "";
        price.Text = "";
    }

    private void ChangeModal(object? sender, EffectiveViewportChangedEventArgs e)
    {
        storages.ItemsSource = _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
        GlobalStorage.Instance.Storages = 
            _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
    }

    private void ClickHandler(object? sender, RoutedEventArgs e)
    {
        modal.IsVisible = !modal.IsVisible;
    }
}