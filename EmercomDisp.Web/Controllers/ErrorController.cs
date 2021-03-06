﻿using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}