using System;
using System.Reactive;
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
    private readonly IUserService _userService = new UserService(new UserRepository(new ApplicationContext()));

    public CompanyPageViewModel()
    {
        SendEmailCommand = ReactiveCommand.Create(ExecuteSendEmailCommand, this.WhenAnyValue(
            x => x.Name,
            x => x.Email,
            x=>x.Country,
            (name, email, country) => !string.IsNullOrWhiteSpace(name) 
                             && !string.IsNullOrWhiteSpace(email)
                             && !string.IsNullOrWhiteSpace(country)));
    }
    
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name));}
    }

    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(nameof(Email)); }
    }
    
    public string Country
    {
        get => _country;
        set { _country = value; OnPropertyChanged(nameof(Country)); }
    }

    public ReactiveCommand<Unit, Unit> SendEmailCommand { get; }

    private void ExecuteSendEmailCommand()
    {
        var company = new Company(Name, Country);
        var user = new User { Name = Name, Password = "password", Company = company };
        
        _userService.AddUser(user);
    }
}