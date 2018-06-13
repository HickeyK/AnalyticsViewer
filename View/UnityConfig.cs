using System.Windows;
using AvDataAccess;
using AvViewModel;
using Microsoft.Practices.Unity;

namespace AnalyticsViewer
{
    public abstract class UnityConfig
    {
        public static void RegisterCoreTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            unityContainer.RegisterType<IUnitOfWork, AvDataContext>();
            unityContainer.RegisterType<IInputBox, InputBoxProvider>();
            unityContainer.RegisterType<IRequestByRunDateViewModel, RequestByRunDateViewModel>();
            unityContainer.RegisterType<IRequestBySecurityViewModel, RequestBySecurityViewModel>();
            unityContainer.RegisterType<ILogFileViewModel, LogFileViewModel>();

            unityContainer.RegisterInstance<IAppConfiguration>(new AppConfiguration());
        }
    }
}


