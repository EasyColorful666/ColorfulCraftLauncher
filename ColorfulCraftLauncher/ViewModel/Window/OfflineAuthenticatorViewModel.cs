using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace ColorfulCraftLauncher
{
    
    public class OfflineAuthenticatorViewModel : ViewModelBase
    {
        SimpleIoc simpleIoc1 = new SimpleIoc();
        SimpleIoc simpleIoc2 = new SimpleIoc();
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        public OfflineAuthenticatorViewModel(MainWindowViewModel viewModel) 
        {
            simpleIoc1.Register<OfflineAuthenticatorViewModel>();
            simpleIoc2.Register<MainWindowViewModel>();
            mainWindowViewModel = viewModel;
        }

        private string sendInfo;
        public string SendInfo
        {
            get { return sendInfo; }
            set { mainWindowViewModel.ReceiveInfo = value; }
        }
        



}



    }
    

