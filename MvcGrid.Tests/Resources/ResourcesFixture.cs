using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcGrid.Helpers;
using System.Text.RegularExpressions;

namespace MvcGrid.Tests.Resources
{
    [TestClass]
    public class ResourcesFixture
    {
        [TestMethod]
        public void GetEmbeddedTemplate()
        {
            Assert.IsTrue(ResourceHelper.GetIgniteTemplate("MobileStockDetailTemplate")
                .StartsWith("<div class=\"stock-row__info-panel\">"), "template starts with <div class=\"stock-row__info-panel\"");
        }

        [TestMethod]
        public void EmbeddedTemplateDoesNotContainCarriageReturns()
        {
            Assert.IsFalse(Regex.IsMatch(ResourceHelper.GetIgniteTemplate("MobileStockDetailTemplate"), "\r\n"));
        }

        [TestMethod]
        public void GetInvalidEmbeddedTemplate()
        {
            try
            {
                ResourceHelper.GetIgniteTemplate("MobileStockDetailTemplatebad");
                Assert.Fail($"Expected a {nameof(ResourceNotFoundException)}");
            }
            catch (ResourceNotFoundException ex)
            {
                Assert.AreEqual($"Could not find HTML template with resource name MvcGrid.Templates.MobileStockDetailTemplatebad.html", ex.Message);
            }
        }
    }
}
