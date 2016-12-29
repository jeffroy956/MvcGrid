using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcGrid.Models;
using System.Collections.Generic;

namespace MvcGrid.Tests.Models
{
    [TestClass]
    public class BookValuePivotFixture
    {
        [TestMethod]
        public void PivotMarketCapForTwoYearsForASingleCompany()
        {
            List<BookValue> pivotSource = new List<BookValue>();
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 0,
                MarketCap = 100,
                TotalAssets = 200,
                TotalLiabilities = 150
            });
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 1,
                MarketCap = 80,
                TotalAssets = 150,
                TotalLiabilities = 125
            });

            List<dynamic> pivotResults = BookValuePivot.Pivot(pivotSource);
            Assert.AreEqual(1, pivotResults.Count, "pivotResults.Count");
            Assert.AreEqual(100, pivotResults[0].MarketCap0);
            Assert.AreEqual(80, pivotResults[0].MarketCap1);
        }

        [TestMethod]
        public void PivotAssetsAndLiabilitiesForTwoYearsForASingleCompany()
        {
            List<BookValue> pivotSource = new List<BookValue>();
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 0,
                MarketCap = 100,
                TotalAssets = 200,
                TotalLiabilities = 150
            });
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 1,
                MarketCap = 80,
                TotalAssets = 150,
                TotalLiabilities = 125
            });

            List<dynamic> pivotResults = BookValuePivot.Pivot(pivotSource);
            Assert.AreEqual(200, pivotResults[0].TotalAssets0);
            Assert.AreEqual(150, pivotResults[0].TotalAssets1);
            Assert.AreEqual(150, pivotResults[0].TotalLiabilities0);
            Assert.AreEqual(125, pivotResults[0].TotalLiabilities1);
        }

        [TestMethod]
        public void PivotBookToMarketForTwoYears()
        {
            List<BookValue> pivotSource = new List<BookValue>();
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 0,
                MarketCap = 100,
                TotalAssets = 200,
                TotalLiabilities = 150
            });
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 1,
                MarketCap = 80,
                TotalAssets = 150,
                TotalLiabilities = 125
            });

            List<dynamic> pivotResults = BookValuePivot.Pivot(pivotSource);
            Assert.AreEqual(0.5M, pivotResults[0].BookToMarket0);
            Assert.AreEqual(0.31M, pivotResults[0].BookToMarket1);
        }

        [TestMethod]
        public void PivotBookToMarketForTwoCustomers()
        {
            List<BookValue> pivotSource = new List<BookValue>();
            pivotSource.Add(new BookValue()
            {
                CompanyName = "a",
                YearsAgo = 0,
                MarketCap = 100,
                TotalAssets = 200,
                TotalLiabilities = 150
            });
            pivotSource.Add(new BookValue()
            {
                CompanyName = "b",
                YearsAgo = 0,
                MarketCap = 80,
                TotalAssets = 150,
                TotalLiabilities = 125
            });

            List<dynamic> pivotResults = BookValuePivot.Pivot(pivotSource);
            Assert.AreEqual(2, pivotResults.Count);

            Assert.AreEqual(0.5M, pivotResults[0].BookToMarket0);
            Assert.AreEqual(0.31M, pivotResults[1].BookToMarket0);
        }

    }
}
