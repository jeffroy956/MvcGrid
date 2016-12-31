using MvcGrid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class CompanyProfilesController : Controller
    {
        private CompanySummaryRepository repo = new CompanySummaryRepository();
        public ActionResult Index(string symbol)
        {
            if (!string.IsNullOrEmpty(symbol))
            {
                return View(new[] { repo.Get(symbol) });
            }
            return View(repo.GetAll());
        }


    }
}