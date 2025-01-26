using System.ComponentModel;
namespace ColorfulCraftLauncher
{
    /// <summary>
    /// YggdrasilAuthenticatorWindow.xaml 的交互逻辑
    /// </summary>
    public partial class YggdrasilAuthenticatorWindow : HandyControl.Controls.Window
    {
        List<string> strings = new List<string>();
        
        public YggdrasilAuthenticatorWindow()
        {
            InitializeComponent();
        }
        public List<string> N
        {
            get { return strings; }
        }

        

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            strings.AddRange([tb1.Text, tb2.Text, tb3.Text]);
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }
    }
}
