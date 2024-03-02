using System.Collections.Generic;
using System.Reactive;
using bank.Models;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using ReactiveUI;

namespace bank.ViewModels;

public class CompanyPageViewModel : ViewModelBase
{
    private string _name;
    private string _email;
    private string _country;
    private string _image;
    private string _nameStorage;
    private string _countryStorage;
    private string _sizeStorage;
    private readonly ICompanyService _companyService =
        new CompanyService(new CompanyRepository());
    private readonly IStorageService _storageService =
        new StorageService(new StorageRepository());
    private readonly IUserService _userService =
        new UserService(new UserRepository());
    
    private  List<Company> _companies = GlobalStorage.Instance.Companies;
    private  List<Storage> _storages = GlobalStorage.Instance.Storages;
    public ReactiveCommand<Unit, Unit> CreateCompanyCommand { get; }
    public ReactiveCommand<Unit, Unit> CreateStorageCommand { get; }
    private Company _selectedCompany;
    private Storage _selectedStorage;
    private bool _isSelectedCompany;

    public CompanyPageViewModel()
    {
        CreateCompanyCommand = ReactiveCommand.Create(ExecuteCreateCompanyCommand, this.WhenAnyValue(
            x => x.Name,
            x => x.Email,
            x => x.Country,
            (name, email, country) => !string.IsNullOrWhiteSpace(name)
                                      && !string.IsNullOrWhiteSpace(email)
                                      && !string.IsNullOrWhiteSpace(country)));

        CreateStorageCommand = ReactiveCommand.Create(ExecuteCreateStorageCommand, this.WhenAnyValue(
            x => x.StorageName,
            x => x.StorageCountry,
            x => x.StorageSize,
            (name, country, size) => !string.IsNullOrWhiteSpace(name)
                                     && !string.IsNullOrWhiteSpace(country)
                                     && !string.IsNullOrWhiteSpace(size)));

        GlobalStorage.Instance.Companies = _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
        Companies = GlobalStorage.Instance.Companies;
    }

    public  List<Company> Companies
    {
        get => _companies;
        set
        {
            _companies = value;
            OnPropertyChanged(nameof(Companies));
            _companies = GlobalStorage.Instance.Companies;
        }
    }

    public void Back()
    {
        SelectedCompany = null;
    }

    public  List<Storage> Storages
    {
        get => _storages;
        set
        {
            _storages = value;
            OnPropertyChanged(nameof(Storages));
            _storages = GlobalStorage.Instance.Storages;
        }
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

    public string StorageCountry
    {
        get => _countryStorage;
        set
        {
            _countryStorage = value;
            OnPropertyChanged(nameof(StorageCountry));
        }
    }

    public string StorageName
    {
        get => _nameStorage;
        set
        {
            _nameStorage = value;
            OnPropertyChanged(nameof(StorageName));
        }
    }

    public string StorageSize
    {
        get => _sizeStorage;
        set
        {
            _sizeStorage = value;
            OnPropertyChanged(nameof(StorageSize));
        }
    }

    public Company SelectedCompany
    {
        get => _selectedCompany;
        set
        {
            if (_selectedCompany != value)
            {
                _selectedCompany = value;
                OnPropertyChanged(nameof(SelectedCompany));
                IsSelectedCompany = _selectedCompany != null;
                GlobalStorage.Instance.SelectedCompany = _selectedCompany;
                if (_selectedCompany != null)
                {
                    GlobalStorage.Instance.Storages = _storageService.GetAllStoragesByCompanyId(SelectedCompany.Id);
                    Storages = GlobalStorage.Instance.Storages;
                }
            }
        }
    }

    public Storage SelectedStorage
    {
        get => _selectedStorage;
        set
        {
            if (_selectedStorage != value)
            {
                _selectedStorage = value;
                OnPropertyChanged(nameof(SelectedStorage));
                GlobalStorage.Instance.SelectedStorage = _selectedStorage;
            }
        }
    }

    public bool IsSelectedCompany
    {
        get => _isSelectedCompany;
        set
        {
            _isSelectedCompany = value;
            OnPropertyChanged(nameof(IsSelectedCompany));
        }
    }

    private void ExecuteCreateStorageCommand()
    {
        var storage = new Storage(StorageName, StorageCountry, StorageSize);
        storage.Company = SelectedCompany;
        List<Storage> storages = _storageService.GetAllStoragesByCompanyId(SelectedCompany.Id);
        storages.Add(storage);
        SelectedCompany.Storages = storages;
        _companyService.Update(SelectedCompany);
        _storageService.Add(storage);
    }

    private void ExecuteCreateCompanyCommand()
    {
        var company = new Company(Name, Country, Image);
        company.User = GlobalStorage.Instance.User;
        List<Company> companies = _companyService.GetAllCompaniesByUserId(GlobalStorage.Instance.User.Id);
        companies.Add(company);
        GlobalStorage.Instance.User.Companies = companies;
        _userService.Update(GlobalStorage.Instance.User);
        _companyService.Add(company);
    }
}