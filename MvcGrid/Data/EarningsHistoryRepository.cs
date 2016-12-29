using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Data
{
    public class EarningsHistoryRepository
    {
        public List<EarningsHistory> GetAll(int totalYears)
        {
            List<EarningsHistory> results = new List<EarningsHistory>();

            foreach (var company in Business.SampleCompanies)
            {
                decimal baseCompanyEarnings = FakeNumbers.GetNextDecimal(10000, 10000000);

                decimal baseSharesOutstanding = FakeNumbers.GetNextDecimal(10000, 10000000);

                for (int i = 0; i < totalYears; i++)
                {
                    baseCompanyEarnings = FakeNumbers.VaryByPercentage(baseCompanyEarnings, 25);
                    baseSharesOutstanding = FakeNumbers.VaryByPercentage(baseSharesOutstanding, 10);

                    EarningsHistory earningsValue = new EarningsHistory()
                    {
                        CompanyName = company.Name,
                        Symbol = company.Symbol,
                        YearsAgo = i,
                        TotalEarnings = baseCompanyEarnings,
                        SharesOutstanding = Convert.ToInt32(baseSharesOutstanding)
                    };

                    results.Add(earningsValue);
                }
            }

            return results;
        }

    }
}