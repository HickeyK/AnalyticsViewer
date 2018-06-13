using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvDataAccess;
using AvEntities;

namespace AvViewModel
{
    public interface IRequestByRunDateViewModel
    {
        IUnitOfWork AvDataContext { get; set; }
        StoreYbAnalyticReq SelectedRequestGroup { get; set; }
        bool IncludePortfolio1 { get; set; }
        bool IncludePortfolio2 { get; set; }
        bool IncludePortfolio3 { get; set; }
        bool IncludePortfolio4 { get; set; }

        ObservableCollection<StoreYbAnalyticReq> Requests { get; set; }

        ObservableCollection<StoreYbAnalyticReq> RequestGroups { get; set; }
    }
}
