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
            var templateContent = ResourceHelper.GetIgniteTemplate("MobileStockDetailTemplate");
            Assert.IsTrue(templateContent.StartsWith("<div class=\"mobile-row__container\">"), 
                $"template starts with <div class=\"mobile-row__container\", actual content: {templateContent}");
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
