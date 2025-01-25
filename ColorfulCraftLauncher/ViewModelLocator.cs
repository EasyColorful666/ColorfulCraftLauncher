using ColorfulCraftLauncher;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace ColorfulCraftLauncher
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register your ViewModels here
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Design Time Logic
            }
            else
            {
                // Run Time Logic
                SimpleIoc.Default.Register<MainWindowViewModel>();
                SimpleIoc.Default.Register<OfflineAuthenticatorViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainWindowViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        /// <summary>
        /// Gets the ProjectChat property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public OfflineAuthenticatorViewModel OfflineAuthenticator
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OfflineAuthenticatorViewModel>();
            }
        }
    }
}