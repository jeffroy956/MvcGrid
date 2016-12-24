using MvcGrid.Data;
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
    }
}