using System.Collections.Generic;
using System.ComponentModel;
using bank.Context;
using bank.Models;

namespace bank.ViewModels;

public class GlobalStorage : INotifyPropertyChanged
{
    private static GlobalStorage _instance;
    public static GlobalStorage Instance => _instance ??= new GlobalStorage();
    private Storage _selectedStorage;
    private Company _selectedCompany;
    public List<Transaction> _Transactions;
    public Company SelectedCompany
    {
        get => _selectedCompany;
        set
        {
            _selectedCompany = value;
            OnPropertyChanged(nameof(SelectedCompany));
        }
    }

    public Storage SelectedStorage
    {
        get => _selectedStorage;
        set
        {
            _selectedStorage = value;
            OnPropertyChanged(nameof(SelectedStorage));
        }
    }

    private  List<Storage> _storages = new();

    public  List<Storage> Storages
    {
        get => _storages;
        set
        {
            _storages = value;
            OnPropertyChanged(nameof(Storages));
        }
    }
    
    public  List<Transaction> Transactions
    {
        get => _Transactions;
        set
        {
            _Transactions = value;
            OnPropertyChanged(nameof(Transactions));
        }
    }

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

    private  List<Product> _products = new ();
    
    public  List<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged(nameof(Products));
        }
    }
    
    private  List<Company> _companies = new ();

    public  List<Company> Companies
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