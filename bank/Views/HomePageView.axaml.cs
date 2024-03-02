using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace bank.Views;

public partial class HomePageView : UserControl
{
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
    }
}