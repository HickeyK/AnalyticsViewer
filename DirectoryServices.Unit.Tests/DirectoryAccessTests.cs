using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DirectoryServices.Unit.Tests
{
    public class DirectoryAccessTests
    {
        [Fact]
        public void da_returns_files()
        {
            // arrange
            var location = Assembly.GetExecutingAssembly().Location;
            var installDir = Path.GetDirectoryName(location);

            //act
            var files = DirectoryAccess.GetDirContent(installDir, "*");


            //assert
            Assert.NotEmpty(files);
        }

        [Fact]
        public void da_finds_files()
        {
            // arrange
            var fileStoreLocations = new FileStorageLocations();
            var fileStoreLocation = fileStoreLocations.Locations.First();

            // act


            var files = DirectoryAccess.GetDirContent(fileStoreLocation.Location, fileStoreLocation.Filter);

            // assert
            Assert.NotEmpty(files);
            Assert.True(files.Count > 0);


        }
    }
}
