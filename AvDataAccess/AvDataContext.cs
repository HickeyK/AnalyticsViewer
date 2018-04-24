﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvEntities;

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

        public Table<StoreYbAnalyticReq> StoreYbAnalyticReqs;

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
                    CadisId =  r.CadisId,
                    Slot = r.Slot,
                    YbYieldbookId =  r.YbYieldbookId,
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


    }
}
