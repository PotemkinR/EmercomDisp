﻿using EmercomDisp.BLL.Providers;
using log4net;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICallProvider _callProvider;

        public HomeController(ICallProvider callProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("Call Provider");
        }

        public ActionResult Index()
        {
            if(!(HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Editor")))
            {
                return RedirectToAction("CallList", "CallList");
            }
            return View();
        }
    }
}