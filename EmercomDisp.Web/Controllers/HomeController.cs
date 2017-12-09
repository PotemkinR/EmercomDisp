using EmercomDisp.BLL.Providers;
using log4net;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");
        private readonly ICallProvider _callProvider;

        public HomeController(ICallProvider callProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("CallProvider");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}