using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvEntities
{
    public class StoreInYbAnalytic
    {
        public DateTime RunDate { get; set; }
        public short PortfolioId { get; set; }
        public string Cusip { get; set; }
        public string Isin { get; set; }
        public string IndicSrc { get; set; }
        public string ModDur { get; set; }

    }
}
