using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DirectoryServices
{
    public class FileStoreLocation
    {
        [XmlElement("Environment")]
        public Environment Environment { get; set; }

        [XmlElement("Location")]
        public string Location { get; set; }

        [XmlElement("Description")]
        public string StoreDescription { get; set; }

        [XmlElement("Filter")]
        public string Filter { get; set; }

        public FileStoreLocation() {}

        public FileStoreLocation(
            Environment environment,
            string storeDesc,
            string location,
            string filter)
        {
            Environment = environment;
            StoreDescription = storeDesc;
            Location = location;
            Filter = filter;
        }

    }


    public enum Environment : byte
    {
        PRD=1,
        UAT=2,
        E2E=3,
        BL=4,
        DV2=5
    }
}
