using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HandyControl.Controls;
using MinecraftLaunch.Components.Authenticator;
using MinecraftLaunch.Components.Fetcher;
using MinecraftLaunch.Components.Installer;
using MinecraftLaunch.Components.Launcher;
using MinecraftLaunch.Components.Resolver;
using MinecraftLaunch.Classes.Models.Auth;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.IO;
using ColorfulCraftLauncher.View.Windows;


namespace ColorfulCraftLauncher
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly GameResolver _resolver;
        private readonly Launcher _launcher;
        private readonly JavaFetcher _javaFetcher;
        private static LaunchConfig _config = new();

        private ObservableCollection<string> _versions;
        private ObservableCollection<string> _localVersions;
        private ObservableCollection<string> _accounts = new ObservableCollection<string>();
        private ObservableCollection<Account> _users = new ObservableCollection<Account>();
        private ObservableCollection<string> _modVersions = new ObservableCollection<string>();
        private string _selectedVersion;
        private string _selectedLocalVersion;
        private string _selectedAccount;
        private string _statusMessage;
        private string _modname;
        private string _n2nlog;
        private string _ip;
        private string _email;
        private string _server;
        private string _passwd;
        private string _loginedAccount;
        private int _selectedIndex;
        private ObservableCollection<string> _javaList;
        private ObservableCollection<string> _usertype = new ObservableCollection<string>();
        private double _progressValue;
        Process edgeProcess;
        
        
        public ICommand LoadCommand { get; }
        public ICommand DownloadJavaCommand { get; }
        public ICommand AuthenticateMicrosoftCommand { get; }
        public ICommand AuthenticateYggdrasilCommand { get; }
        public ICommand AuthenticateOfflineCommand { get; }
        public ICommand InstallGameCoreCommand { get; }
        public ICommand LaunchGameCommand { get; }
        public ICommand SelectAccountCommand { get; }
        public ICommand SearchModsCommand { get; }
        public ICommand TapInstallCommand { get; }
        public ICommand RefreshGameListCommand { get; }

        public ICommand N2NStartCommand { get; }
        public ObservableCollection<string> Versions
        {
            get => _versions;
            set => Set(ref _versions, value);
        }

        public ObservableCollection<string> LocalVersions
        {
            get => _localVersions;
            set => Set(ref _localVersions, value);
        }

        public ObservableCollection<string> Accounts
        {
            get => _accounts;
            set => Set(ref _accounts, value);
        }
        public string LoginedAccount
        {
            get => _loginedAccount;
            set => Set(ref _loginedAccount, value);
        }
        public ObservableCollection<Account> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }
        public ObservableCollection<string> ModVersions
        {
            get => _modVersions;
            set => Set(ref _modVersions, value);
        }
        public ObservableCollection<string> JavaList
        {
            get => _javaList;
            set => Set(ref _javaList, value);
        }

        public string SelectedVersion
        {
            get => _selectedVersion;
            set => Set(ref _selectedVersion, value);
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }
        public string ModName
        {
            get => _modname;
            set => Set(ref _modname, value);
        }

        public string SelectedLocalVersion
        {
            get => _selectedLocalVersion;
            set => Set(ref _selectedLocalVersion, value);
        }

        public string SelectedAccount
        {
            get => _selectedAccount;
            set => Set(ref _selectedAccount, value);
        }
 
        
        public string IP
        {
            get => _ip;
            set => Set(ref _ip, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => Set(ref _statusMessage, value);
        }
        public string N2NLog
        {
            get => _n2nlog;
            set => Set(ref _n2nlog, value);
        }

        public double ProgressValue
        {
            get => _progressValue;
            set => Set(ref _progressValue, value);
        }

        public MainWindowViewModel()
        {
            _resolver = new GameResolver(".minecraft");
            _launcher = new Launcher(_resolver, _config);
            _javaFetcher = new JavaFetcher();
            Accounts = new ObservableCollection<string>();
            Versions = new ObservableCollection<string>();
            LocalVersions = new ObservableCollection<string>();
            _users = new ObservableCollection<Account>();
            LoadCommand = new RelayCommand(LoadData);
            AuthenticateMicrosoftCommand = new RelayCommand(AuthenticateMicrosoftAsync);
            AuthenticateYggdrasilCommand = new RelayCommand(AuthenticateYggdrasilAsync);
            AuthenticateOfflineCommand = new RelayCommand(AuthenticateOffline);
            InstallGameCoreCommand = new RelayCommand(InstallGameCoreAsync);
            LaunchGameCommand = new RelayCommand(LaunchGameAsync);
            SelectAccountCommand = new RelayCommand(SelectAccount);
            SearchModsCommand = new RelayCommand(SearchMods);
            TapInstallCommand = new RelayCommand(TapInstall);
            N2NStartCommand = new RelayCommand(N2NStart);
            RefreshGameListCommand =  new RelayCommand(RefreshGameList);
            DownloadJavaCommand = new RelayCommand(DownloadJava);



        }

        private string receiveInfo;
        public string ReceiveInfo
        {
            get { return receiveInfo; }
            set { receiveInfo = value; }
        }








        private async void LoadData()
        {
            var versions = await VanlliaInstaller.EnumerableGameCoreAsync();
            Versions.Clear();
            foreach (var ver in versions)
            {
                Versions.Add(ver.Id);
            }

            var localVersions = _resolver.GetGameEntitys();
            LocalVersions.Clear();
            foreach (var ver in localVersions)
            {
                LocalVersions.Add(ver.Id);
            }
            _accounts.Add("test");
            OfflineAuthenticator authenticator = new("test");
            OfflineAccount offlineAccount = authenticator.Authenticate();
            _users.Add(offlineAccount);
            _usertype.Add("Offline");
            
        }

        private async void AuthenticateMicrosoftAsync()
        {
            
                MicrosoftAuthenticator authenticator = new("f4c1c237-e68f-4866-a998-82f0db041c55");
                await authenticator.DeviceFlowAuthAsync(dc =>
                {
                    Growl.Success("设备代码: " + dc.UserCode + " 设备代码已写入剪贴板");
                    string textToCopy = dc.UserCode;

                    Clipboard.SetText(textToCopy, TextDataFormat.UnicodeText);
                    Clipboard.Flush();
                    Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = dc.VerificationUrl });
                });

                var userProfile = await authenticator.AuthenticateAsync();
                Accounts.Add(userProfile.Name + " (Microsoft)");
                _users.Add(userProfile);
                _usertype.Add("Microsoft");

        }

        private async void AuthenticateYggdrasilAsync()
        {
            try
            {
                YggdrasilAuthenticatorWindow window = new();
                window.ShowDialog();
                YggdrasilAuthenticator authenticator = new(_server,_email,_passwd);
                var userProfile = await authenticator.AuthenticateAsync();
                Accounts.Add(userProfile.First().Name + " (Yggdrasil)");
                _users.Add(userProfile.First() as YggdrasilAccount);
                _usertype.Add("Yggdrasil");
            }
            catch (Exception ex)
            {
                Growl.Error($"用户登录失败" + "\n" + $"{ex.Message}");
            }
        }

        private void AuthenticateOffline()
        {
            OfflineAuthenticatorWindow sender = new OfflineAuthenticatorWindow();
            sender.ShowDialog();
            try
            {
                Growl.Success("离线用户已创建");

                OfflineAuthenticator authenticator = new(ReceiveInfo);
                Accounts.Add(authenticator.Authenticate().Name + " (Offline)");
                _users.Add(authenticator.Authenticate());
                _usertype.Add("Offline");
        }
            catch (Exception ex)
            {
                Growl.Error($"用户登录失败"  + $"{ex.Message}");
            }
}

        private async void InstallGameCoreAsync()
        {
            if (string.IsNullOrEmpty(SelectedVersion))
            {
                Growl.Error("请选择一个游戏版本。");
                return;
            }

            var installer = new VanlliaInstaller(_resolver, SelectedVersion);

            installer.ProgressChanged += (_, x) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ProgressValue = x.Progress * 100;
                    StatusMessage = x.ProgressStatus;
                });
            };

            var result = await installer.InstallAsync();

            if (result)
            {
                Growl.Success($"游戏核心{SelectedVersion}安装成功");
                LocalVersions.Add(SelectedVersion);
            }
        }

        private async void LaunchGameAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(SelectedLocalVersion))
                {
                    Growl.Error("请选择一个游戏版本。");
                    return;
                }

                if (!Accounts.Any())
                {
                    Growl.Error("请先添加一个用户。");
                    return;
                }

                var javaList = _javaFetcher.Fetch();
                _config.JvmConfig = new JvmConfig(JavaUtil.GetCurrentJava(javaList, _resolver.GetGameEntity(SelectedLocalVersion)).JavaPath);

                var game = await _launcher.LaunchAsync(SelectedLocalVersion);
                Growl.Success($"成功启动游戏版本: {SelectedLocalVersion}");
            }
            catch
            {
                 Growl.Ask("未检测到Java,是否安装Java21 ", isConfirmed =>
                {
                    DownloadJavaCommand.Execute(null);
                    JavaFetcher javaFetcher = new();
                    var javas = javaFetcher.FetchAsync();
                    foreach (var java in javas.Result.ToList()) 
                    { 
                        _javaList.Add(java.JavaVersion+$"({java.JavaPath})");
                    }
                    return false;
                });

            }
        }
       
        void DownloadJava()
        {
            DownloadJavaWindow downloadJavaWindow = new DownloadJavaWindow();
            downloadJavaWindow.ShowDialog();
        }
        private async void SelectAccount()
        {

            if (_selectedAccount == null)
            {
                Growl.Error("请选择一个账户 。");
                return;
            }

            _config.Account = _users[SelectedIndex];
            Growl.Success($"{_accounts[SelectedIndex]}，欢迎回来");
            

              
        }

        
        private async void SearchMods()
        {
            ModrinthFetcher modrinthFetcher = new();
            var mods = await modrinthFetcher.SearchResourcesAsync("JEI");
            ModVersions.Clear();
            foreach (var mod in mods)
            {
                ModVersions.Add(mod.Name);
            }

        }
        public static bool RunCmdCommand(string command, string arguments, string workDirPath = "", string resultstr = "")
        {
            bool installed = true;

            ProcessStartInfo processInfo = null;

            Process process = null;

            try
            {
                processInfo = new ProcessStartInfo(command, arguments);

                processInfo.UseShellExecute = true;

                processInfo.RedirectStandardOutput = true;

                processInfo.RedirectStandardError = true;

                processInfo.CreateNoWindow = true;

                if (!string.IsNullOrWhiteSpace(workDirPath))
                {
                    processInfo.WorkingDirectory = workDirPath;
                }

                

                process = new Process();

                process.StartInfo = processInfo;

                process.Start();

                string str = process.StandardOutput.ReadToEnd();

                string err = process.StandardError.ReadToEnd();

                int exitCode = process.ExitCode;

               

                if (!string.IsNullOrWhiteSpace(str))
                {
                    
                    if (str.IndexOf(resultstr) == -1)
                    {
                        installed = false;
                    }
                }



            }
            catch (Exception e)
            {
               
            }
            finally
            {
                processInfo = null;

                if (process != null)
                {
                    process.Close();
                    process = null;
                }
            }

            return installed;
        }
        private void TapInstall()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TAP");

            string command = Path.Combine(path, "tapinstall");

            string arga = "install \"OemVista.inf\" tap0901";

            string reStr = "Drivers installed successfully";

            string msg = "安装失败";

            if (RunCmdCommand(command, arga, path, reStr))
            {
                msg = "安装成功";
            }
            Growl.Info(msg);
        }
        private async void N2NStart()
        {
            

            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "N2N");

            string command = Path.Combine(path, "edge.exe");

            //删除当前正在运行的进程
            KillProcessByName("edge.exe", command);

            string arga = "-c easycolorful -l 103.40.13.21:20741 -E -x 1 -I D876AE2D2310";


            Growl.Success("开始执行N2N客户端");

            await Task.Run(() =>
            {
                try
                {

                    ProcessStartInfo processInfo = new ProcessStartInfo(command, arga);

                    processInfo.UseShellExecute = true;

                    processInfo.RedirectStandardOutput = true;

                    processInfo.RedirectStandardError = true;

                    processInfo.CreateNoWindow = true;

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        processInfo.WorkingDirectory = path;
                    }

                    edgeProcess = new Process();

                    edgeProcess.StartInfo = processInfo;

                    edgeProcess.OutputDataReceived += (sender1, e1) =>
                    {
                        _n2nlog += e1.Data + "\r\n";
                    };

                    edgeProcess.ErrorDataReceived += (sender1, e1) =>
                    {
                        if (!string.IsNullOrEmpty(e1.Data))
                        {
                            _n2nlog += e1.Data + "\r\n";
                        }
                    };

                    edgeProcess.Start();
                    edgeProcess.BeginOutputReadLine();
                    edgeProcess.BeginErrorReadLine();
                }
                catch (Exception ex)
                {
                    _n2nlog += ex + "\r\n";
                }
            });
        }
        void KillProcessByName(string name, string filePath)
        {
            var allprocess = System.Diagnostics.Process.GetProcessesByName(name);

            foreach (System.Diagnostics.Process p in allprocess)
            {
                if (filePath == p.MainModule.FileName)
                {
                    p.Kill();
                    p.Close();
                }
            }
        }
        void RefreshGameList()
        {
            foreach(var ver in _resolver.GetGameEntitys()){
                _localVersions.Add(ver.Id);
            }
        }


    }
}