using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class BookValuePivot
    {

        public static List<dynamic> Pivot(IEnumerable<BookValue> pivotSource)
        {
            List<dynamic> pivotData = new List<dynamic>();

            var groupedData = pivotSource.GroupBy(bv => bv.CompanyName);

            int numYears = pivotSource.Max(ps => ps.YearsAgo) + 1;

            foreach(var companyData in groupedData)
            {
                dynamic pivotedBookValue = new ExpandoObject();
                var pivotCols = (IDictionary<string, object>)pivotedBookValue;
                pivotedBookValue.CompanyName = companyData.Key;
                pivotedBookValue.Symbol = companyData.First().Symbol;
                pivotedBookValue.NumYears = numYears;
                pivotedBookValue.BaseYear = DateTime.Now.Year;

                foreach (var annualBookValue in companyData.OrderBy(bv => bv.YearsAgo))
                {
                    pivotCols[$"MarketCap{annualBookValue.YearsAgo}"] = annualBookValue.MarketCap;
                    pivotCols[$"TotalAssets{annualBookValue.YearsAgo}"] = annualBookValue.TotalAssets;
                    pivotCols[$"TotalLiabilities{annualBookValue.YearsAgo}"] = annualBookValue.TotalLiabilities;
                    pivotCols[$"BookToMarket{ annualBookValue.YearsAgo}"] = annualBookValue.BookToMarket;
                }

                pivotData.Add(pivotedBookValue);
            }


            return pivotData;
        }

    }
}