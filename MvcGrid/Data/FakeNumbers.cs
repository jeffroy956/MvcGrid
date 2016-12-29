using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Data
{
    public static class FakeNumbers
    {
        private static Random _rand = new Random();

        public static decimal GetNextDecimal(decimal floor, decimal maxDelta)
        {
            return floor + Math.Round((decimal)_rand.NextDouble() * maxDelta, 2);
        }

        public static decimal VaryByPercentage(decimal target, decimal maxPercentage)
        {
            decimal percentVariation = GetNextDecimal(0, maxPercentage * 2) - maxPercentage;

            return Math.Round(target * (1M + percentVariation / 100M), 2);
        }

    }
}