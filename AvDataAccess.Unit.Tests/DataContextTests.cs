using System.Data.Linq.Mapping;
using AvDataAccess;
using Moq;
using Xunit;
using System.Reflection;

namespace AvDataAccess.Unit.Tests
{
    public class DataContextTests
    {
        [Fact]
        public void Ctor_DoesNotReturnNull()
        {
            var databaseConfigFileName = "AnalyticViewer.database.config";
            //var installationDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var installationDirectory = @"c:\Dev\AnalyticsViewer\AvDataAccess";
            var databaseConfig = System.IO.Path.Combine(installationDirectory, databaseConfigFileName);
            var mappingSource = XmlMappingSource.FromUrl(databaseConfig);
            var avDataContext = new AvDataContext("Data Source=caddbe2e01;Initial Catalog=CADIS_E2E02;Integrated Security=True", mappingSource, false, 30);

            Assert.NotNull(avDataContext);
        }
    }
}
