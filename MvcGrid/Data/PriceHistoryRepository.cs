using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Data
{
    public class PriceHistoryRepository
    {

        private Random _rand = new Random();

        public List<PriceHistory> GetAll()
        {
            List<PriceHistory> stocks = new List<PriceHistory>();
            foreach(var company in Business.SampleCompanies)
            {
                stocks.Add(new PriceHistory()
                {
                    Symbol = company.Symbol,
                    Industry = company.Industry,
                    CompanyName = company.Name,
                    Price5YearsAgo = GetNextDecimal(20, 50),
                    Price4YearsAgo = GetNextDecimal(20, 50),
                    Price3YearsAgo = GetNextDecimal(20, 50),
                    Price2YearsAgo = GetNextDecimal(20, 50),
                    Price1YearsAgo = GetNextDecimal(20, 50),
                    CurrentAsk = GetNextDecimal(20, 50),
                    CurrentBid = GetNextDecimal(20, 50),
                    CurrentPrice = GetNextDecimal(20, 50),
                    CurrentDividend = GetNextDecimal(1, 5),
                });
            }
            return stocks;
        }

        private decimal GetNextDecimal(decimal floor, decimal maxDelta)
        {
            return floor + Math.Round((decimal)_rand.NextDouble() * maxDelta, 2);
        }

    }
}