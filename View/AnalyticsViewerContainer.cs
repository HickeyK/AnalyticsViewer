using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvDataAccess;
using AvViewModel;
using Microsoft.Practices.Unity;

namespace AnalyticsViewer
{
    public sealed class AnalyticsViewerContainer : ContainerBuilder
    {
        public override void RegisterCoreTypes()
        {
            base.RegisterCoreTypes();
        }

        public override void RegisterInstances()
        {
            base.RegisterInstances();
        }

        public IMainWindowViewModel CreateMainWindowViewModel()
        {
            return Container.Resolve<MainWindowViewModel>();
        }

    }
}
