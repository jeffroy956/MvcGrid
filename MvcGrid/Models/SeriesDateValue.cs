using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class SeriesDateValue
    {
        public SeriesDateValue(DateTime date, decimal value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }
    }
}