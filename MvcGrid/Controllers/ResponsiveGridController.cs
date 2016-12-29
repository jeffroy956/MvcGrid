using MvcGrid.Data;
using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class ResponsiveGridController : Controller
    {
        // GET: ResponsiveGrid
        public ActionResult Index()
        {
            PriceHistoryRepository swRepo = new PriceHistoryRepository();

            return View(swRepo.GetAll().Take(10).AsQueryable());
        }

        public ActionResult Book()
        {
            BookValueRepository bvr = new BookValueRepository();
            var pivotedData = BookValuePivot.Pivot(bvr.GetAll(5));

            return View(pivotedData.AsQueryable());
        }

        public ActionResult Earnings()
        {
            EarningsHistoryRepository ehr = new EarningsHistoryRepository();
            var pivotedData = EarningsHistoryPivot.Pivot(ehr.GetAll(5));

            return View(pivotedData.AsQueryable());
        }
    }
}