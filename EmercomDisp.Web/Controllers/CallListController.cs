using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Calls;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace EmercomDisp.Web.Controllers
{
    [Authorize(Roles ="User")]
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
                var callList = _callProvider.GetCalls()
                    .Where(c => c.CallTime.Date == DateTime.Today);
                model.CallList = callList.OrderByDescending(c => c.IsActive);
            }
            else
            {
                var callList = _callProvider.GetCallsByCategory(category)
                    .Where(c => c.CallTime.Date == DateTime.Today);
                model.CallList = callList.OrderByDescending(c => c.IsActive);
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
                Address = call.Address,
                Reason = call.Reason,
                Category = call.Category,
                Status = call.IsActive ? "Active" : "Closed"
            };
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult _SearchPanel()
        {
            var categories = _callProvider.GetCategories();
            var model = new CallSearchModel()
            {
                Categories = categories.Select(category => new SelectListItem()
                {
                    Text = category,
                    Value = category
                })
            };
            return PartialView(model);
        }

        public ActionResult Search()
        {          
            var calls = _callProvider.GetCalls();
            var model = new CallListViewModel()
            {
                CallList = calls              
            };
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Search(int? id, string address, string category)
        {
            var calls = _callProvider.GetCalls()
                .Where(c => c.Category.Contains(category))
                .Where(c => c.Address.Contains(address));
            
            if(id != null)
            {
                calls = calls.Where(c => c.Id == id);
            }

            var model = new CallListViewModel()
            {
                CallList = calls
            };
            return PartialView("_SearchResult", model);
        }
    }
}