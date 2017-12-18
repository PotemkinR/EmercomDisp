using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Calls;
using System;
using System.Web.Mvc;
using System.Linq;

namespace EmercomDisp.Web.Controllers
{
    [Authorize]
    public class CallListController : Controller
    {
        private readonly ICallProvider _callProvider;

        public CallListController(ICallProvider callProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("Call Provider");
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

        [ChildActionOnly]
        public PartialViewResult _SearchPanel()
        {
            var model = new CallSearchModel();
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult Search(int? id, string address)
        {
            var calls = _callProvider.GetCalls()
                .Where(c => c.Address.Contains(address));

            if(id != null)
            {
                calls = calls.Where(c => c.Id == (int)id);
            }

            var model = new CallListViewModel()
            {
                CallList = calls
            };
            return PartialView("_SearchResult", model);
        }
    }
}