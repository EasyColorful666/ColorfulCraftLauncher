using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyControl.Controls;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace ColorfulCraftLauncher
{
    /// <summary>
    /// OfflineAuthenticatorWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OfflineAuthenticatorWindow : HandyControl.Controls.Window
    {

        private static OfflineAuthenticatorWindow staticInstance = null;

        public OfflineAuthenticatorWindow()
        {
            InitializeComponent();

            this.Closed += WindowOnClosed;

        }
        public static OfflineAuthenticatorWindow GetInstance()
        {
            if (staticInstance == null)
            {
                staticInstance = new OfflineAuthenticatorWindow();
            }

            return staticInstance;

        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
        private void WindowOnClosed(object sender, System.EventArgs e)
        {
            staticInstance = null;
        }



    }
}

    

