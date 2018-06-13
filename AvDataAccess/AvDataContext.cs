using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvEntities;

namespace AvDataAccess
{
    public class AvDataContext : DataContext, IUnitOfWork
    {
        public AvDataContext(
            string connectionString,
            MappingSource mappingSource,
            Boolean objectTrackingEnabled,
            int commandTimeout) : base(connectionString, mappingSource)
        {
            base.ObjectTrackingEnabled = ObjectTrackingEnabled;
            base.CommandTimeout = commandTimeout;
        }

        #region Linq Tables


        public Table<StoreYbAnalyticReq> StoreYbAnalyticReqs
        {
            get { return GetTable<StoreYbAnalyticReq>(); }
        }

        public Table<StoreInYbAnalytic> StoreInYbAnalytic
        {
            get { return GetTable<StoreInYbAnalytic>(); }
        }


        #endregion

        public List<DateTime> RunDateList()
        {
            return this.StoreYbAnalyticReqs.Select(r => r.RunDate).Distinct().ToList();
        }

        public List<StoreYbAnalyticReq> RequestGroup()
        {
            return this.StoreYbAnalyticReqs
                .Select
                (r => new StoreYbAnalyticReq()
                {
                    RunDate = r.RunDate,
                    ValDate = r.ValDate,
                    Slot = r.Slot
                })
                .Distinct()
                .OrderByDescending(r => r.RunDate)
                .ToList();
        }

        public List<StoreYbAnalyticReq> GetRequests(StoreYbAnalyticReq requestGroup)
        {
            return this.StoreYbAnalyticReqs
                .Where(r => r.RunDate == requestGroup.RunDate &&
                            r.ValDate == requestGroup.ValDate &&
                            r.Slot == requestGroup.Slot &&
                            r.PortfolioId == requestGroup.PortfolioId)
                .Select
                (r => new StoreYbAnalyticReq()
                {
                    RunDate = r.RunDate,
                    ValDate = r.ValDate,
                    CadisId = r.CadisId,
                    Slot = r.Slot,
                    YbYieldbookId = r.YbYieldbookId,
                    PortfolioId = r.PortfolioId,
                    UserBond = r.UserBond,
                    ParAmt = r.ParAmt,
                    PrepayModel = r.PrepayModel,
                    PricingLevel = r.PricingLevel,
                    OutputFile = r.OutputFile,
                    OutputLine = r.OutputLine,
                    OmittedFromSecondRun = r.OmittedFromSecondRun
                })
                .Distinct()
                .OrderBy(r => r.CadisId)
                .ToList();
        }

        public List<StoreYbAnalyticReq> GetRequestsByCadisId(int cadisId)
        {
            return this.StoreYbAnalyticReqs
                .Where(r => r.CadisId == cadisId)
                .Select
                (r => new StoreYbAnalyticReq()
                {
                    RunDate = r.RunDate,
                    ValDate = r.ValDate,
                    CadisId = r.CadisId,
                    Slot = r.Slot,
                    YbYieldbookId = r.YbYieldbookId,
                    PortfolioId = r.PortfolioId,
                    UserBond = r.UserBond,
                    ParAmt = r.ParAmt,
                    PrepayModel = r.PrepayModel,
                    PricingLevel = r.PricingLevel,
                    OutputFile = r.OutputFile,
                    OutputLine = r.OutputLine,
                    OmittedFromSecondRun = r.OmittedFromSecondRun
                })
                .Distinct()
                .OrderByDescending(r => r.RunDate)
                .ToList();
        }

        public List<StoreYbAnalyticReq> GetRequestsByYieldbookId(string yieldbookId)
        {
            return this.StoreYbAnalyticReqs
                .Where(r => r.YbYieldbookId == yieldbookId)
                .Select
                (r => new StoreYbAnalyticReq()
                {
                    RunDate = r.RunDate,
                    ValDate = r.ValDate,
                    CadisId = r.CadisId,
                    Slot = r.Slot,
                    YbYieldbookId = r.YbYieldbookId,
                    PortfolioId = r.PortfolioId,
                    UserBond = r.UserBond,
                    ParAmt = r.ParAmt,
                    PrepayModel = r.PrepayModel,
                    PricingLevel = r.PricingLevel,
                    OutputFile = r.OutputFile,
                    OutputLine = r.OutputLine,
                    OmittedFromSecondRun = r.OmittedFromSecondRun
                })
                .Distinct()
                .OrderByDescending(r => r.RunDate)
                .ToList();
        }


        // Not sure if I can add hints to make this usable from linq to sql query
        private StoreYbAnalyticReq CreateStoreYbAnalyticReq(StoreYbAnalyticReq r)
        {
            return new StoreYbAnalyticReq()
            {
                RunDate = r.RunDate,
                ValDate = r.ValDate,
                CadisId = r.CadisId,
                Slot = r.Slot,
                YbYieldbookId = r.YbYieldbookId,
                PortfolioId = r.PortfolioId,
                UserBond = r.UserBond,
                ParAmt = r.ParAmt,
                PrepayModel = r.PrepayModel,
                PricingLevel = r.PricingLevel,
                OutputFile = r.OutputFile,
                OutputLine = r.OutputLine,
                OmittedFromSecondRun = r.OmittedFromSecondRun
            };
        }


        private StoreInYbAnalytic CreateStoreInYbAnalytic(StoreInYbAnalytic r)
        {
            return new StoreInYbAnalytic()
            {
                RunDate = r.RunDate,
                PortfolioId = r.PortfolioId,
                Cusip = r.Cusip,
                Isin = r.Isin,

            };
        }

    }







}

