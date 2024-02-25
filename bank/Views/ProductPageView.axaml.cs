using Avalonia.Controls;
using Avalonia.Interactivity;

namespace bank.Views;

public partial class ProductPageView : UserControl
{
    public ProductPageView()
    {
        InitializeComponent();
    }

    public void Next(object source, RoutedEventArgs args)
    {
        slides.Next();
    }

    public void Previous(object source, RoutedEventArgs args) 
    {
        slides.Previous();
    }
}
