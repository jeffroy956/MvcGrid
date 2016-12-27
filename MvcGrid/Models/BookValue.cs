using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class BookValue
    {
        public string CompanyName { get; set; }
        public string Symbol { get; set; }

        public int YearsAgo { get; set; }
        public decimal MarketCap { get; set; }
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal BookToMarket
        {
            get
            {
                return Decimal.Round((TotalAssets - TotalLiabilities) / MarketCap, 2);
            }
        }

    }
}