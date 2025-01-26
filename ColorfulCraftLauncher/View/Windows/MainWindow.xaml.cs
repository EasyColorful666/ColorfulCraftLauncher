
using System.Windows;

namespace ColorfulCraftLauncher
{
    public partial class MainWindow : HandyControl.Controls.Window

    {
        MainWindowViewModel viewmodel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = viewmodel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewmodel.LoadCommand.Execute(null);
        }
    }
}