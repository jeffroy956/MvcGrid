using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MvcGrid.Models;

namespace MvcGrid.Tests.Models
{
    [TestClass]
    public class EarningsHistoryPivotFixture
    {
        [TestMethod]
        public void PivotEarningsPerShareForTwoYearsForASingleCompany()
        {
            List<EarningsHistory> pivotSource = new List<EarningsHistory>();
            pivotSource.Add(new EarningsHistory()
            {
                CompanyName = "a",
                YearsAgo = 0,
                SharesOutstanding = 100,
                TotalEarnings = 200
            });
            pivotSource.Add(new EarningsHistory()
            {
                CompanyName = "a",
                YearsAgo = 1,
                SharesOutstanding = 100,
                TotalEarnings = 150
            });

            List<dynamic> pivotResults = EarningsHistoryPivot.Pivot(pivotSource);
            Assert.AreEqual(2M, pivotResults[0].EPS0);
            Assert.AreEqual(1.5M, pivotResults[0].EPS1);
        }
    }
}
