using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.CallViewModels;
using System.Linq;
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
        
        public ActionResult CallList(UrgencyEnum? urgency)
        {
            CallListViewModel model = new CallListViewModel();
            if (urgency != null)
            {
                model.CallList = _callProvider.GetCalls()
                .Where(c => c.Category == urgency);
            }
            else
            {
                model.CallList = _callProvider.GetCalls();
            }
            
            return View(model);
        }

        public PartialViewResult CallListItem(int callId)
        {
            Call _call = new Call();
            _call = _callProvider.GetCalls().Where(c => c.Id == callId).Single();

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