using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvDataAccess
{
    public class AvDataContext : DataContext
    {
        public AvDataContext(
            string connectionString,
            MappingSource mappingSource,
            Boolean objectTrackingEnabled,
            int commandTimeout) : base(connectionString, mappingSource)
        {
            var x = new AvEntities.StoreYbAnalyticReq();

            base.ObjectTrackingEnabled = ObjectTrackingEnabled;
            base.CommandTimeout = commandTimeout;
        }


    }
}
