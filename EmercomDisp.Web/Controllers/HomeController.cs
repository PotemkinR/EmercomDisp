﻿using EmercomDisp.BLL.Providers;
using EmercomDisp.Web.Models;
using log4net;
using System.Linq;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");
        private readonly ICallProvider _callProvider;

        public HomeController(ICallProvider callProvider)
        {
            _callProvider = callProvider;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}