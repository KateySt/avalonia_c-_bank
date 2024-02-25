using System.Collections.Generic;
using System.ComponentModel;
using bank.Models;

namespace bank.ViewModels;

public class GlobalStorage : INotifyPropertyChanged
{
    private static GlobalStorage _instance;
    public static GlobalStorage Instance => _instance ??= new GlobalStorage();

    private User _user;

    public User User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged(nameof(User));
            IsUserEmpty = _user != null;
            OnPropertyChanged(nameof(IsUserEmpty));
        }
    }

    private bool _isUserEmpty;

    public bool IsUserEmpty
    {
        get => _isUserEmpty;
        set
        {
            _isUserEmpty = value;
            OnPropertyChanged(nameof(IsUserEmpty));
        }
    }

    private IEnumerable<Company> _companies= new List<Company>();

    public IEnumerable<Company> Companies
    {
        get => _companies;
        set
        {
            _companies = value;
            OnPropertyChanged(nameof(Companies));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}