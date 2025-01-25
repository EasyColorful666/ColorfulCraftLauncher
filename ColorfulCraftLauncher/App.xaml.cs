using System.Configuration;
using System.Data;
using System.Windows;

namespace ColorfulCraftLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.StartupUri = new Uri("View/Windows/MainWindow.xaml", UriKind.Relative);
        }
    }

}
