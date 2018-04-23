using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvEntities
{
    public class StoreYbAnalyticReq
    {
        public DateTime RunDate { get; set; }
        public int CadisId { get; set; }
        public DateTime ValDate { get; set; }
        public short Slot { get; set; }
        public string YbYieldbookId { get; set; }
        public short PortfolioId { get; set; }
        public char UserBond { get; set; }
        public string ParAmt { get; set; }
        public string PricingLevel { get; set; }
        public string OutputFile { get; set; }
        public string OutputLine { get; set; }
        public string PrepayModel { get; set; }
        public char? OmittedFromSecondRun { get; set; }
    }
}
