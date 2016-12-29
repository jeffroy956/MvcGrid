using MvcGrid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    public class Dashboard
    {
        public Dashboard()
        {
            PriceHistoryRepository swRepo = new PriceHistoryRepository();
            PriceData = swRepo.GetAll().Take(10).AsQueryable();

            BookValueRepository bvr = new BookValueRepository();
            BookValueData = BookValuePivot.Pivot(bvr.GetAll(5)).Take(5).AsQueryable();

            EarningsHistoryRepository ehr = new EarningsHistoryRepository();
            EarningsData = EarningsHistoryPivot.Pivot(ehr.GetAll(5)).Take(5).AsQueryable();
        }

        public IQueryable<PriceHistory> PriceData { get; private set; }
        public IQueryable<dynamic> BookValueData { get; private set; }

        public IQueryable<dynamic> EarningsData { get; private set; }
    }

}