using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class Business
    {
        public string Industry { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        public static Business[] SampleCompanies = new[]
        {
            new Business() { Symbol = "EXC", Industry = "Utility", Name = "Exelon" },
            new Business() { Symbol = "PPL", Industry = "Utility", Name = "PPL Corporation " },
            new Business() { Symbol = "NGG", Industry = "Utility", Name = "National Grid" },
            new Business() { Symbol = "JNJ", Industry = "Pharma", Name = "Johnson & Johnson" },
            new Business() { Symbol = "MRK", Industry = "Pharma", Name = "Merck & Co." },
            new Business() { Symbol = "CSX", Industry = "Railroad", Name = "CSX Corporation" },
            new Business() { Symbol = "UNP", Industry = "Railroad", Name = "Union Pacific" },
            new Business() { Symbol = "CVX", Industry = "Oilgas", Name = "Chevron" },
            new Business() { Symbol = "XOM", Industry = "Oilgas", Name = "Exxon Mobil" },
            new Business() { Symbol = "INTC", Industry = "Semiconductors", Name = "Intel" },
            new Business() { Symbol = "GLW", Industry = "Semiconductors", Name = "Corning" },
            new Business() { Symbol = "HMC", Industry = "Auto", Name = "Honda Motor Company" },
            new Business() { Symbol = "BLK", Industry = "Banking", Name = "BlackRock" },
            new Business() { Symbol = "OC", Industry = "Semiconductors", Name = "Owens Corning" },
            new Business() { Symbol = "TD", Industry = "Banking", Name = "TD Bank" },
        };
    }

}