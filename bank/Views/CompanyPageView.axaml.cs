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
        CompanyModal.IsVisible = false;
        ModalStorage.IsVisible = false;
    }
    
    public void ShowModal(object sender, RoutedEventArgs args)
    {
        CompanyModal.IsVisible = !CompanyModal.IsVisible;
        CompanyName.Text = "";
        CompanyEmail.Text = "";
        CompanyCountry.Text = "";
        CompanyImage.Text = "";
    }
    
    public void ChangeModal(object? sender, EffectiveViewportChangedEventArgs effectiveViewportChangedEventArgs)
    {
        ListCompanies.ItemsSource =  _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
        GlobalStorage.Instance.Companies =  _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
    }
    
    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        CompanyModal.IsVisible = !CompanyModal.IsVisible;
        
    }
    
    public void ClickStorageHandler(object sender, RoutedEventArgs args)
    {
       ModalStorage.IsVisible = !ModalStorage.IsVisible;
    }

    private void ShowModalStorage(object? sender, RoutedEventArgs e)
    {
        ModalStorage.IsVisible = !ModalStorage.IsVisible;
        SizeStorage.Text = "";
        NameStorage.Text = "";
        CountryStorage.Text = "";
    }

    private void ChangeModalStorage(object? sender, EffectiveViewportChangedEventArgs e)
    {
        if (GlobalStorage.Instance.SelectedCompany != null)
        {
            StorageDataGrid.ItemsSource =  _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
            GlobalStorage.Instance.Storages =  _storageService.GetAllStoragesByCompanyId(GlobalStorage.Instance.SelectedCompany.Id);
        }
    }
}