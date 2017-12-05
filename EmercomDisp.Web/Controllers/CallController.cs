using EmercomDisp.BLL.Providers;
using EmercomDisp.Web.Models.CallViewModels;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class CallController : Controller
    {
        private readonly ICallProvider _callProvider;

        public CallController(ICallProvider callProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("CallProvider");
        }

        public ActionResult CallDetails(int id)
        {
            var call = _callProvider.GetCallById(id);
            var model = new CallDetailsViewModel
            {
                Call = call
            };

            return View(model);
        }
    }
}