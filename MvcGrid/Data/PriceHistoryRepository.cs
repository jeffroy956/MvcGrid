using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Data
{
    public class PriceHistoryRepository
    {

        public List<PriceHistory> GetAll()
        {
            List<PriceHistory> prices = new List<PriceHistory>();
            foreach(var company in Business.SampleCompanies)
            {
                PriceHistory priceRecord = new PriceHistory()
                {
                    Symbol = company.Symbol,
                    Industry = company.Industry,
                    CompanyName = company.Name,
                    Price5YearsAgo = FakeNumbers.GetNextDecimal(20, 50),
                    Price4YearsAgo = FakeNumbers.GetNextDecimal(20, 50),
                    Price3YearsAgo = FakeNumbers.GetNextDecimal(20, 50),
                    Price2YearsAgo = FakeNumbers.GetNextDecimal(20, 50),
                    Price1YearsAgo = FakeNumbers.GetNextDecimal(20, 50),
                    CurrentPrice = FakeNumbers.GetNextDecimal(20, 50),
                    CurrentDividend = FakeNumbers.GetNextDecimal(1, 5),
                };

                priceRecord.CurrentAsk = priceRecord.CurrentPrice + FakeNumbers.GetNextDecimal(0, 0.1M);
                priceRecord.CurrentBid = priceRecord.CurrentPrice - FakeNumbers.GetNextDecimal(0, 0.1M);

                prices.Add(priceRecord);
            }
            return prices;
        }

    }
}