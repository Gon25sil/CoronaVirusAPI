using CoronaVirus.Services.API;
using CoronaVirus.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CoronaVirus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CoronaCountriesViewModel>();
            services.AddSingleton<CoronaCountryInformationViewModel>();
            services.AddSingleton<APICoronavirusCountryService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainViewModel mainWindowView = _serviceProvider.GetService<MainViewModel>();
            mainWindowView.LoadData();

            MainWindow mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.DataContext = mainWindowView;

            mainWindow.Show();
            
        }
    }
}
