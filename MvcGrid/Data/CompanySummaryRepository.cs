using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Data
{
    public class CompanySummaryRepository
    {
        public List<CompanySummary> GetAll()
        {
            List<CompanySummary> companies = new List<CompanySummary>();

            foreach (var company in Business.SampleCompanies)
            {
                CompanySummary summary = GenerateSummary(company);

                companies.Add(summary);
            }

            return companies;
        }

        public CompanySummary Get(string symbol)
        {
            var business = Business.SampleCompanies.First(sc => sc.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase));

            return GenerateSummary(business);
        }

        private static CompanySummary GenerateSummary(Business company)
        {
            CompanySummary summary = new CompanySummary()
            {
                CompanyProfile = company,
                CurrentPrice = FakeNumbers.GetNextDecimal(20, 200),
                AverageVolume = FakeNumbers.GetNextDecimal(8, 50),
                SharesOutstanding = FakeNumbers.GetNextDecimal(1M, 2),
                EPS = FakeNumbers.GetNextDecimal(1, 10),
                AnnualDividend = FakeNumbers.GetNextDecimal(1, 6),
                ExDividend = DateTime.Today.AddDays(-1 * FakeNumbers.GetNextInt(0, 90)),
                PercentHeldByInstitutions = FakeNumbers.GetNextDecimal(10, 85)
            };

            for(int i = 0; i < 30; i++)
            {
                if (i == 0)
                {
                    summary.PriceHistory.Add(new SeriesDateValue(DateTime.Today, summary.CurrentPrice));
                }
                else
                {
                    summary.PriceHistory.Add(new SeriesDateValue(DateTime.Today.AddDays(-1 * i),
                        Math.Max(10M, FakeNumbers.VaryByPercentage(summary.PriceHistory[i - 1].Value, 1M))));
                }
            }

            return summary;
        }
    }
}