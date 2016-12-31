using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Data
{
    public class BookValueRepository
    {
        public List<BookValue> GetAll(int totalYears)
        {
            List<BookValue> results = new List<BookValue>();

            foreach (var company in Business.SampleCompanies)
            {
                Decimal baseMarketCap = FakeNumbers.GetNextDecimal(50000, 100000);
                for (int i = 0; i < totalYears; i++)
                {
                    baseMarketCap = FakeNumbers.VaryByPercentage(baseMarketCap, 10);
                    BookValue bookValue = new BookValue()
                    {
                        CompanyName = company.Name,
                        Industry = company.Industry,
                        Symbol = company.Symbol,
                        YearsAgo = i,
                        MarketCap = baseMarketCap
                    };

                    bookValue.TotalAssets = FakeNumbers.VaryByPercentage(bookValue.MarketCap + 50000, 5);
                    bookValue.TotalLiabilities = FakeNumbers.VaryByPercentage(bookValue.MarketCap - 50000, 2);

                    results.Add(bookValue);
                }
            }

            return results;
        }
    }
}