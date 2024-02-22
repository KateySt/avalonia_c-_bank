using CommunityToolkit.Mvvm.ComponentModel;

namespace bank.ViewModels;

public partial class CompanyPageViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isButtonEnabled = true;
}