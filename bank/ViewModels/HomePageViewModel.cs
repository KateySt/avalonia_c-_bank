using System.Reactive;
using bank.Context;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using ReactiveUI;

namespace bank.ViewModels;

public class HomePageViewModel : ViewModelBase
{
    private string _name;
    private string _password;
    private User _user;
    private bool _isEmpty;
    private readonly IUserService _userService = new UserService(new UserRepository(new ApplicationContext()));
    
    public HomePageViewModel()
    {
        CreateOrLoginCommand = ReactiveCommand.Create(CreateUser, this.WhenAnyValue(
            x => x.Name,
            x => x.Password,
            (name,password) => !string.IsNullOrWhiteSpace(name) 
                                      && !string.IsNullOrWhiteSpace(password)));
    }
    
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name));}
    }

    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(nameof(Password)); }
    }

    public User User
    {
        get => _user;
        set   { 
            _user = value; 
            OnPropertyChanged(nameof(User)); 
            IsUserEmpty = _user != null;
        }
    }
    
    public ReactiveCommand<Unit, Unit> CreateOrLoginCommand { get; }

    public bool IsUserEmpty
    {
        get => _isEmpty;
        set { _isEmpty = value; OnPropertyChanged(nameof(IsUserEmpty)); }
    }

    private void CreateUser()
    {
        var newUser = new User { Name = Name, Password = Password };
        User = _userService.CreateOrFindUser(newUser);
    }
}