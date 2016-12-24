using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcGrid.Models;

namespace MvcGrid.Tests.Models
{
    [TestClass]
    public class YearsAgoFixture
    {
        [TestMethod]
        public void ReplaceYearsAgoLabels()
        {
            string content = "${6YearsAgoLabel},${1YearsAgoLabel}";
            Assert.AreEqual("2010,2015", YearsAgo.ReplaceContentLabels(content, 2016));
        }
    }
}
