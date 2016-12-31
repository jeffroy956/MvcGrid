using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class CompanySummary
    {
        public Business CompanyProfile { get; set; }
        public Decimal CurrentPrice { get; set; }
        public decimal AverageVolume { get; set; }
        public decimal MarketCap { get; set; }
        public decimal SharesOutstanding { get; set; }
        public decimal EPS { get; set; }
        public decimal PERatio { get; set; }
        public decimal AnnualDividend { get; set; }
        public decimal DividendYield
        {
            get
            {
                return Math.Round((AnnualDividend / CurrentPrice) * 100, 2);
            }
        }
        public DateTime ExDividend { get; set; }

        public decimal PercentHeldByInstitutions { get; set; }

    }
}