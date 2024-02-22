using bank.ViewModels.Models;
using FluentAvalonia.UI.Windowing;

namespace bank.Views;

public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();

        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;

        SplashScreen = new ComplexSplashScreen();
    }
}