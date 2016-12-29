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
                for(int i = 0; i < totalYears; i++)
                {
                    BookValue bookValue = new BookValue()
                    {
                        CompanyName = company.Name,
                        Symbol = company.Symbol,
                        YearsAgo = i,
                        MarketCap = FakeNumbers.GetNextDecimal(50000, 100000)
                    };

                    bookValue.TotalAssets = FakeNumbers.GetNextDecimal(bookValue.MarketCap + 50000, 100000);
                    bookValue.TotalLiabilities = FakeNumbers.GetNextDecimal(bookValue.MarketCap - 50000, 100000);

                    results.Add(bookValue);
                }
            }

            return results;
        }
    }
}