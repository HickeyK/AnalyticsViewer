using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvDataAccess.Unit.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public AvDataContext AvDataContext { get; set; }

        public DatabaseFixture()
        {
            var databaseConfigFileName = "AnalyticViewer.database.config";
            var installationDirectory = @"c:\Dev\AnalyticsViewer\AvDataAccess";
            var databaseConfig = System.IO.Path.Combine(installationDirectory, databaseConfigFileName);
            var mappingSource = XmlMappingSource.FromUrl(databaseConfig);
            AvDataContext = new AvDataContext("Data Source=lonbscadsqlbl01;Initial Catalog=CADIS_E2E01;Integrated Security=True", mappingSource, false, 30);

        }

        public void Dispose()
        {
            AvDataContext.Dispose();
        }


    }
}
