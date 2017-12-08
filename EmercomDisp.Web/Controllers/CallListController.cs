using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Calls;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class CallListController : Controller
    {
        private readonly ICallProvider _callProvider;

        public CallListController(ICallProvider callProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("CallProvider");
        }
        
        public ActionResult CallList(string category)
        {
            var model = new CallListViewModel();
            if (string.IsNullOrEmpty(category))
            {
                model.CallList = _callProvider.GetCalls();
            }
            else
            {
                model.CallList = _callProvider.GetCallsByCategory(category);
            }

            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult CallListItem(Call call)
        {
            var model = new CallItemViewModel
            {
                CallId = call.Id,
                CallTime = call.CallTime,
                Address = call.Address
            };
            return PartialView(model);
        }
    }
}