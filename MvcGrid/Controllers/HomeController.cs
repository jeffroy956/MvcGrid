﻿using MvcGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Dashboard dashboard = new Dashboard();

            return View(dashboard);
        }
        
    }
}