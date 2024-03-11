using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace WPF_UI;

/// <summary>
/// Interaction logic for App.xaml
/// Represents the main entry point for the WPF application.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Defines a service provider for dependency injection.
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the App class.
    /// </summary>
    public App()
    {
        // Create a new service collection for registering services.
        IServiceCollection serviceCollection = new ServiceCollection();
        // Configure services with the designated method
        ConfigureServices(services: serviceCollection);
        // Build the service provider from the service collection
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    /// <summary>
    /// Configures services to be used by the application.
    /// </summary>
    /// <param name="services">The collection of services to configure.</param>
    private void ConfigureServices(IServiceCollection services)
    {
        // Register the main window for dependency injection as a transient service
        services.AddTransient<MainWindow>();
    }

    /// <summary>
    /// Raises the Startup event.
    /// </summary>
    /// <param name="e">A StartupEventArgs that contains the event data.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e: e);
        // Retrieve the main window from the service provider and display it
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow?.Show();
    }
}
