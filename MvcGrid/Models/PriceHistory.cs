using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class PriceHistory
    {
        public string Industry { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Price5YearsAgo { get; set; }
        public decimal Price4YearsAgo { get; set; }
        public decimal Price3YearsAgo { get; set; }
        public decimal Price2YearsAgo { get; set; }
        public decimal Price1YearsAgo { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal CurrentAsk { get; set; }
        public decimal CurrentBid { get; set; }
        public decimal CurrentDividend { get; set; }




    }
}