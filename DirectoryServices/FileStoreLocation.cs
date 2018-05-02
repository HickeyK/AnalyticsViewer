using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryServices
{
    public class FileStoreLocation
    {
        public Environment Environment { get; set; }
        public string StoreId { get; set; }
        public string StoreDescription { get; set; }
        public string Location { get; set; }
        public string Filter { get; set; }

        public FileStoreLocation(
            Environment environment,
            string storeId,
            string storeDesc,
            string location,
            string filter)
        {
            Environment = environment;
            StoreId = storeId;
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
