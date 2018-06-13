using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvEntities;

namespace AvDataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Table<StoreYbAnalyticReq> StoreYbAnalyticReqs { get; }

        Table<StoreInYbAnalytic> StoreInYbAnalytic { get; }

        List<DateTime> RunDateList();

        List<StoreYbAnalyticReq> RequestGroup();

        List<StoreYbAnalyticReq> GetRequests(StoreYbAnalyticReq requestGroup);

        List<StoreYbAnalyticReq> GetRequestsByCadisId(int cadisId);

        List<StoreYbAnalyticReq> GetRequestsByYieldbookId(string yieldbookId);




    }
}
