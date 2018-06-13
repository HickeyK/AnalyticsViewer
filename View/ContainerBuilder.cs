using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvDataAccess;
using Microsoft.Practices.Unity;

namespace AnalyticsViewer
{
    public abstract class ContainerBuilder
    {
        protected readonly IUnityContainer Container;
        protected IAppConfiguration AppConfiguration;
        protected AvDataContext repository; 

        protected ContainerBuilder()
        {
            Container = new UnityContainer();
        }


        public virtual void RegisterCoreTypes()
        {
            UnityConfig.RegisterCoreTypes(Container);
        }

        public virtual void RegisterInstances()
        {
            AppConfiguration = Container.Resolve<IAppConfiguration>();
            var connectionString = AppConfiguration.DatabaseConnection;

            var mappingSource = XmlMappingSource.FromUrl(AppConfiguration.DatabaseConfigFilename);
            var timeout = AppConfiguration.DatabaseTimeout;
            repository = new AvDataContext(connectionString, mappingSource, false, timeout);

            Container.RegisterInstance<IUnitOfWork>(repository);
        }



    }
}
