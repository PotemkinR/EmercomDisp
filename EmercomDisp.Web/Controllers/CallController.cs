using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Calls;
using EmercomDisp.Web.Models.Equipment_;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize]
    public class CallController : Controller
    {
        private readonly ICallProvider _callProvider;
        private readonly IVictimsProvider _victimsProvider;

        public CallController(ICallProvider callProvider,
            IVictimsProvider victimsProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("Call Provider");
            _victimsProvider = victimsProvider ?? throw new ArgumentNullException("Victims Provider");
        }

        public ActionResult CallDetails(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var call = _callProvider.GetCallById((int)id);
            var victims = _victimsProvider.GetVictimsByIncidentId((int)id);

            if (call.Id != 0)
            {
                var model = new CallDetailsViewModel
                {
                    Call = call,
                    VictimsCount = victims.Count()
                };

                return View(model);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult EditCall(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var call = _callProvider.GetCallById((int)id);
            var categories = _callProvider.GetCategories();

            if(call.Id != 0)
            {
                var model = new CallEditModel()
                {
                    Id = call.Id,
                    Address = call.Address,
                    Reason = call.Reason,
                    CallTime = call.CallTime,
                    IncidentDescription = call.IncidentDescription,
                    SelectedCategory = call.Category,
                    IncidentCause = call.IncidentCause,
                    Categories = categories.Select(category => new SelectListItem()
                    {
                        Value = category,
                        Text = category
                    })
                };
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCall(CallEditModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedCall = new Call()
                {
                    Id = model.Id,
                    Address = model.Address,
                    Reason = model.Reason,
                    CallTime = model.CallTime,
                    Category = model.SelectedCategory,
                    IncidentDescription = model.IncidentDescription,
                    IncidentCause = model.IncidentCause
                };

                _callProvider.UpdateCall(updatedCall);
                return RedirectToAction("CallDetails", new { id = model.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteCall(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var call = _callProvider.GetCallById((int)id);
            if(call != null)
            {
                var model = new CallDetailsViewModel()
                {
                    Call = call
                };

                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteCall(int id)
        {
            _callProvider.DeleteCall(id);
            return RedirectToAction("CallList", "CallList");
        }
    }
}