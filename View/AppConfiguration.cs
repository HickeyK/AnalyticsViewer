using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsViewer
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly NameValueCollection _appSettings;

        public AppConfiguration() : this(ConfigurationManager.AppSettings) {}

        public AppConfiguration(NameValueCollection appSettings)
        {
            _appSettings = appSettings;
        }

        public string TestString {
            get
            {
                return _appSettings["TestString"];
            }
        }

        public string DatabaseConnection
        {
            get { return AnalyticsViewer.Properties.Settings.Default.TestConnection; }
        }

        public string DatabaseConfigFilename
        {
            get { return AnalyticsViewer.Properties.Settings.Default.DatabaseConfigFilename; }
        }

        public short DatabaseTimeout
        {
            get
            {
                return AnalyticsViewer.Properties.Settings.Default.DatabaseTimeout;
            }
        }
    }
}
