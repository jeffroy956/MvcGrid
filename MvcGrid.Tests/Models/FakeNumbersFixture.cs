using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcGrid.Data;
using MvcGrid.Models;

namespace MvcGrid.Tests.Models
{
    [TestClass]
    public class FakeNumbersFixture
    {
        [TestMethod]
        public void VaryByPercentageStaysWithinRange()
        {
            decimal baseNumber = 100M;
            for(int i = 0; i < 100; i++)
            {
                decimal adjustedNumber = FakeNumbers.VaryByPercentage(baseNumber, 10);
                Assert.IsTrue(adjustedNumber >= 90M && adjustedNumber <= 110M, $"Adjusted number should be between 90 and 100, actual value: {adjustedNumber}");
            }
        }

        [TestMethod]
        public void VaryByPercentageHasVariationsThatApproachUpperLimit()
        {
            decimal baseNumber = 100M;
            decimal maxNumber = 0m;
            for (int i = 0; i < 100; i++)
            {
                decimal adjustedNumber = FakeNumbers.VaryByPercentage(baseNumber, 10);

                if (adjustedNumber > maxNumber)
                {
                    maxNumber = adjustedNumber;
                }
            }

            Assert.IsTrue(maxNumber >= 109M, $"One adjusted number should be greater than 109, actual max: {maxNumber}");
        }

        [TestMethod]
        public void VaryByPercentageHasVariationsThatApproachLowerLimit()
        {
            decimal baseNumber = 100M;
            decimal minNumber = 0m;
            for (int i = 0; i < 100; i++)
            {
                decimal adjustedNumber = FakeNumbers.VaryByPercentage(baseNumber, 10);

                if (adjustedNumber < minNumber)
                {
                    minNumber = adjustedNumber;
                }
            }

            Assert.IsTrue(minNumber <= 91M, $"One adjusted number should be less than 91, actual min: {minNumber}");
        }
    }
}
