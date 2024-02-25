using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive;
using Avalonia.Media.Imaging;
using bank.Context;
using bank.Helpers;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace bank.ViewModels;

public partial class CompanyPageViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isButtonEnabled = true;
    private string _name;
    private string _email;
    private string _country;
    private string _image;

    private readonly ICompanyService _companyService =
        new CompanyService(new CompanyRepository(new ApplicationContext()));
    private readonly IUserService _userService = new UserService(new UserRepository(new ApplicationContext()));
    private IEnumerable<Company> _companies = GlobalStorage.Instance.Companies;

    public IEnumerable<Company> Companies
    {
        get => _companies;
        set
        {
            _companies = value;
            OnPropertyChanged(nameof(Companies));
            _companies = GlobalStorage.Instance.Companies;
        }
    }

    public CompanyPageViewModel()
    {
        CreateCompanyCommand = ReactiveCommand.Create(ExecuteCreateCompanyCommand, this.WhenAnyValue(
            x => x.Name,
            x => x.Email,
            x => x.Country,
            (name, email, country) => !string.IsNullOrWhiteSpace(name)
                                      && !string.IsNullOrWhiteSpace(email)
                                      && !string.IsNullOrWhiteSpace(country)));
        
        GlobalStorage.Instance.Companies =  _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
        Companies = GlobalStorage.Instance.Companies;
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
    
    public string Image
    {
        get => _image;
        set
        {
           _image = value;
            OnPropertyChanged(nameof(Image));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Country
    {
        get => _country;
        set
        {
            _country = value;
            OnPropertyChanged(nameof(Country));
        }
    }

    public ReactiveCommand<Unit, Unit> CreateCompanyCommand { get; }

    private void ExecuteCreateCompanyCommand()
    {
        var c = new Company(Name, Country, Image); 
        c.User = GlobalStorage.Instance.User;
        List<Company> cc = new List<Company>(_companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id));
        cc.Add(c);
        GlobalStorage.Instance.User.Company =  cc;
        _userService.Update(GlobalStorage.Instance.User);
        _companyService.Add(c);
    }
}