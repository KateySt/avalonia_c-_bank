using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media;
using bank.Views;
using FluentAvalonia.UI.Windowing;

namespace bank.ViewModels.Models;

public class ComplexSplashScreen : IApplicationSplashScreen
{
    public ComplexSplashScreen()
    {
        SplashScreenContent = new FluentSplashScreenView();
    }

    public string AppName => "";

    public IImage? AppIcon => null;

    public object SplashScreenContent { get; }

    public int MinimumShowTime => 0;

    public async Task RunTasks(CancellationToken token)
    {
        await ((FluentSplashScreenView)SplashScreenContent).InitApp();
    }
}
