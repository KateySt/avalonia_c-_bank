using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using bank.Context;
using bank.Helpers;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using bank.ViewModels;

namespace bank.Views;

public partial class CompanyPageView : UserControl
{
    private readonly ICompanyService _companyService =
        new CompanyService(new CompanyRepository(new ApplicationContext()));
    public CompanyPageView()
    {
        InitializeComponent();
        modal.IsVisible = false;
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
}
