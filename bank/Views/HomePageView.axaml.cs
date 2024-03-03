using Avalonia.Controls;
using Avalonia.Input;
using bank.Repository;
using bank.Services;
using bank.Services.Impl;
using bank.ViewModels;

namespace bank.Views;

public partial class HomePageView : UserControl
{
    private readonly ITransactionService _transactionService = new TransactionService(new TransactionRepository());
    public HomePageView()
    {
        InitializeComponent();
        ComboBoxCompany.SelectedIndex = 0;
        ComboBoxProduct.SelectedIndex = 0;
    }

    private void InputElement_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        ComboBoxCompany.SelectedIndex = 0;
        ComboBoxProduct.SelectedIndex = 0;
        CountProduct.Text = "0";
        if (GlobalStorage.Instance.User != null)
        {
             GlobalStorage.Instance.Transactions =
                        _transactionService.GetAllTransactionsByUserId(GlobalStorage.Instance.User.Id);
                    TransactionDataGrid.ItemsSource = GlobalStorage.Instance.Transactions;
        }
    }
}