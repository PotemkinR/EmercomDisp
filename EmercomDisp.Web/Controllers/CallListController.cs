using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.CallViewModels;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class CallListController : Controller
    {
        private readonly ICallProvider _callProvider;

        public CallListController(ICallProvider callProvider)
        {
            _callProvider = callProvider;
        }
        
        public ActionResult CallList()
        {
            CallListViewModel model = new CallListViewModel
            {
                CallList = _callProvider.GetCalls()
            };

            return View(model);
        }

        public PartialViewResult CallListItem(int callId)
        {
            Call _call = _callProvider.GetCallById(callId);

            CallItemViewModel model = new CallItemViewModel
            {
                CallId = _call.Id,
                Adress = _call.Adress,
                CallTime = _call.CallTime
            };
            return PartialView(model);
        }
    }
}