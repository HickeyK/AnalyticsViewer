using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryServices
{
    public class FileStoreLocations
    {
        public List<FileStoreLocation> Locations { get; set; }

        public FileStoreLocations()
        {
            // Eventually aim to import from an xml file

            Locations = new List<FileStoreLocation>()
            {
                new FileStoreLocation(
                    Environment.E2E,
                    "YB Port Out", "Output from the Yield Book batch, .out, .ref",
                    @"\\LONBSCADSQLEE01\E$\CADIS\Jobs\YieldBookAnalytic\Data\Archive",
                    "AMPORT*"),

                new FileStoreLocation(
                    Environment.PRD,
                    "YB Port Out", "Output from the Yield Book batch, .out, .ref",
                    @"\\CADDBPRD01\E$\CADIS\Jobs\YieldBookAnalytic\Data\Archive",
                    "AMPORT*")
            };

        }
    }
}
