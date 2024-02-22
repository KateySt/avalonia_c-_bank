using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using bank.ViewModels;
using bank.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
namespace bank;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var locator = new ViewLocator();
        DataTemplates.Add(locator);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = new ServiceCollection();
            ConfigureViewModels(services);
            ConfigureViews(services);
            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);

            var vm = Ioc.Default.GetService<MainWindowViewModel>();
            var view = (Window)locator.Build(vm);
            view.DataContext = vm;

            desktop.MainWindow = view;
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    static void ConfigureViewModels(IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<CompanyPageViewModel>();
        services.AddSingleton<ProductPageViewModel>();
        services.AddSingleton<StoragePageViewModel>();
        services.AddSingleton<CustomSplashScreenViewModel>();
    }
    
    static void ConfigureViews(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<HomePageView>();
        services.AddSingleton<CompanyPageView>();
        services.AddSingleton<ProductPageView>();
        services.AddSingleton<StoragePageView>();
        services.AddSingleton<CustomSplashScreenView>();
    }
}
