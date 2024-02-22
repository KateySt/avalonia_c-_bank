using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using bank.ViewModels;
using bank.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace bank;

public class ViewLocator : IDataTemplate
{
    private readonly Dictionary<Type, Func<Control?>> _locator = new();

    public ViewLocator()
    {
        RegisterViewFactory<MainWindowViewModel, MainWindow>();
        RegisterViewFactory<HomePageViewModel, HomePageView>();
        RegisterViewFactory<CompanyPageViewModel, CompanyPageView>();
        RegisterViewFactory<ProductPageViewModel, ProductPageView>();
        RegisterViewFactory<StoragePageViewModel, StoragePageView>();
        RegisterViewFactory<CustomSplashScreenViewModel, CustomSplashScreenView>();
    }

    public Control Build(object? data)
    {
        if (data is null)
        {
            return new TextBlock { Text = "No VM provided" };
        }

        _locator.TryGetValue(data.GetType(), out var factory);

        return factory?.Invoke() ?? new TextBlock { Text = $"VM Not Registered: {data.GetType()}" };
    }

    public bool Match(object? data)
    {
        return data is ObservableObject;
    }
    
    private void RegisterViewFactory<TViewModel, TView>()
        where TViewModel : class
        where TView : Control
        => _locator.Add(
            typeof(TViewModel), 
            Design.IsDesignMode 
                ? Activator.CreateInstance<TView> 
                : Ioc.Default.GetService<TView>);
}
