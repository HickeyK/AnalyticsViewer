using System.Windows;

namespace AnalyticsViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AnalyticsViewerContainer _analyticsViewerContainer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _analyticsViewerContainer = new AnalyticsViewerContainer();
            _analyticsViewerContainer.RegisterCoreTypes();
            _analyticsViewerContainer.RegisterInstances();


            var mw = new MainWindow(_analyticsViewerContainer.CreateMainWindowViewModel());
            mw.Show();

        }
    }

}
