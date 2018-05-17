using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AvDataAccess
{
    [XmlRoot("AdHocQueries")]
    public class AdHocQueries
    {
        [XmlElement("AdHocQuery")] public List<AdHocQuery> Queries { get; set; }


        public static AdHocQueries Create()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(AdHocQueries));

            using (FileStream xmlIn =
                new FileStream(@"C:\Dev\AnalyticsViewer\AvDataAccess\AdHocQueries.xml", FileMode.Open))
            {
                return (AdHocQueries) serializer.Deserialize(xmlIn);
            }

        }
    }
}
