using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DirectoryServices
{
    [XmlRoot("FileStorageLocations")]
    public class FileStorageLocations
    {
        [XmlElement("FileStore")]
        public List<FileStoreLocation> Locations { get; set; }

        public static FileStorageLocations Create()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(FileStorageLocations));

            using (FileStream xmlIn = new FileStream(@"C:\Dev\AnalyticsViewer\DirectoryServices\FileStorageLocations.xml", FileMode.Open))
            {
                return (FileStorageLocations) serializer.Deserialize(xmlIn);
            }


            //Locations = new List<FileStoreLocation>()
            //{
            //    new FileStoreLocation(
            //        Environment.E2E,
            //        "YB Port Out", "Output from the Yield Book batch, .out, .ref",
            //        @"\\LONBSCADSQLEE01\E$\CADIS\Jobs\YieldBookAnalytic\Data\Archive",
            //        "AMPORT*"),

            //    new FileStoreLocation(
            //        Environment.PRD,
            //        "YB Port Out", "Output from the Yield Book batch, .out, .ref",
            //        @"\\CADDBPRD01\E$\CADIS\Jobs\YieldBookAnalytic\Data\Archive",
            //        "AMPORT*"),

            //    new FileStoreLocation(
            //    Environment.PRD,
            //    "YB UB Log", "Output from the Yield Book User  Bond batch, .out, .ref",
            //    @"\\CADDBPRD01\E$\CADIS\Jobs\YieldBookUserBonds\Logs",
            //    "*"),

            //    new FileStoreLocation(
            //    Environment.PRD,
            //    "YB UB Upload", "User Bond upload file, .txt",
            //    @"\\CADDBPRD01\E$\CADIS\Jobs\YieldBookUserBonds\Data\Archive",
            //    "USERBOND*")
            //};

        }
    }
}
