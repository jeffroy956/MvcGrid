using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class EarningsHistoryPivot
    {
        public static List<dynamic> Pivot(IEnumerable<EarningsHistory> pivotSource)
        {
            List<dynamic> pivotData = new List<dynamic>();

            int numYears = pivotSource.Max(ps => ps.YearsAgo) + 1;
            var groupedData = pivotSource.GroupBy(bv => bv.CompanyName);

            foreach (var companyData in groupedData)
            {
                dynamic pivotedEarningsPerShare = new ExpandoObject();
                var pivotCols = (IDictionary<string, object>)pivotedEarningsPerShare;
                pivotedEarningsPerShare.CompanyName = companyData.Key;
                pivotedEarningsPerShare.Industry = companyData.First().Industry;
                pivotedEarningsPerShare.Symbol = companyData.First().Symbol;
                pivotedEarningsPerShare.NumYears = numYears;
                pivotedEarningsPerShare.BaseYear = DateTime.Now.Year;

                foreach (var earningsHistory in companyData.OrderBy(bv => bv.YearsAgo))
                {
                    pivotCols[$"EPS{earningsHistory.YearsAgo}"] = earningsHistory.EarningsPerShare;
                }

                pivotData.Add(pivotedEarningsPerShare);
            }


            return pivotData;
        }

    }
}