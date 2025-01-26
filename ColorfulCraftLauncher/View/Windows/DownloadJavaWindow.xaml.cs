using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ColorfulCraftLauncher.View.Windows
{
    /// <summary>
    /// DownloadJavaWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DownloadJavaWindow : Window
    {
        public DownloadJavaWindow()
        {
            InitializeComponent();
        }
        async void DownloadJava()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileAsync(new Uri("https://download.oracle.com/java/21/latest/jdk-21_windows-x64_bin.exe"), @".//jdk-21_windows-x64_bin.exe");
                client.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error == null)
                    {
                       Growl.Success("下载完成,安装中.");
                        Process.Start(new ProcessStartInfo("jdk-21_windows-x64_bin.exe") { UseShellExecute = true,Arguments="/wait /s" });

                    }
                    else
                    {
                        Growl.Error("下载失败!");
                    }
                };
            }
        }
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pb1.Value = e.ProgressPercentage;
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DownloadJava();
        }
    }
}
