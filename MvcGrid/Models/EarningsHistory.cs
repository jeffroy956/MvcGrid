using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class EarningsHistory
    {
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Symbol { get; set; }

        public int YearsAgo { get; set; }
        public decimal TotalEarnings { get; set; }
        public int SharesOutstanding { get; set; }
        public decimal EarningsPerShare
        {
            get
            {
                return Decimal.Round(TotalEarnings / (Decimal)SharesOutstanding, 2);
            }
        }

    }
}