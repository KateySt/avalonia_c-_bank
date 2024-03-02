using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using bank.ViewModels;

namespace bank.Views;

public partial class CompanyPageView : UserControl
{
    private readonly ICompanyService _companyService =
        new CompanyService(new CompanyRepository());
    private readonly IStorageService _storageService =
        new StorageService(new StorageRepository());
    public CompanyPageView()
    {
        InitializeComponent();
        modal.IsVisible = false;
        modalStorage.IsVisible = false;
    }
    
    public void ShowModal(object sender, RoutedEventArgs args)
    {
        modal.IsVisible = !modal.IsVisible;
        name.Text = "";
        email.Text = "";
        country.Text = "";
        image.Text = "";
    }
    
    public void ChangeModal(object? sender, EffectiveViewportChangedEventArgs effectiveViewportChangedEventArgs)
    {
        companies.ItemsSource =  _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
        GlobalStorage.Instance.Companies =  _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
    }
    
    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        modal.IsVisible = !modal.IsVisible;
        
    }
    
    public void ClickStorageHandler(object sender, RoutedEventArgs args)
    {
       modalStorage.IsVisible = !modalStorage.IsVisible;
        
    }

    private void ShowModalStorage(object? sender, RoutedEventArgs e)
    {
        modalStorage.IsVisible = !modalStorage.IsVisible;
        sizeStorage.Text = "";
        nameStorage.Text = "";
        countryStorage.Text = "";
    }

    private void ChangeModalStorage(object? sender, EffectiveViewportChangedEventArgs e)
    {
        if (GlobalStorage.Instance.SelectedCompany != null)
        {
            storageDataGrid.ItemsSource =  _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
            GlobalStorage.Instance.Storages =  _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
        }
    }
}