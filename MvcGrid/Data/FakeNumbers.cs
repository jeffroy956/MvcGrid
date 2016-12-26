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

    }
}