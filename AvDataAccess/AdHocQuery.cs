using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AvDataAccess
{
    public class AdHocQuery
    {
        [XmlElement("ConnectionString")]
        public string ConnectionString { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Sql")]
        public string Sql { get; set; }
    }
}
