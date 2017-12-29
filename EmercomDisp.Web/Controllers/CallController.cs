using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Calls;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize(Roles ="User")]
    public class CallController : Controller
    {
        private readonly ICallProvider _callProvider;
        private readonly IVictimsProvider _victimsProvider;
        private readonly IBrigadeProvider _brigadeProvider;
        private readonly ICallResponseProvider _callResponseProvider;

        public CallController(ICallProvider callProvider,
            IVictimsProvider victimsProvider,
            IBrigadeProvider brigadeProvider,
            ICallResponseProvider callResponseProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("Call Provider");
            _victimsProvider = victimsProvider ?? throw new ArgumentNullException("Victims Provider");
            _brigadeProvider = brigadeProvider ?? throw new ArgumentNullException("Brigade Provider");
            _callResponseProvider = callResponseProvider ?? throw new ArgumentNullException("Call Response Provider");
        }

        public ActionResult CallDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var call = _callProvider.GetCallById((int)id);
            var victims = _victimsProvider.GetVictimsByIncidentId((int)id);
            var callResponses = _callResponseProvider.GetCallResponsesForCall((int)id)
                .Where(callResponse => callResponse.IsActive == true);

            if (call.Id != 0)
            {
                var model = new CallDetailsViewModel
                {
                    Call = call,
                    VictimsCount = victims.Count(),
                    HasActiveCallResponses = callResponses.Any()
                };

                return View(model);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult CreateCall()
        {
            var categories = _callProvider.GetCategories();
            var brigades = _brigadeProvider.GetBrigades();
            var model = new CallCreateModel()
            {
                Categories = categories.Select(category => new SelectListItem()
                {
                    Text = category,
                    Value = category
                }),
                SelectedCategory = categories.FirstOrDefault()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCall(CallCreateModel model)
        {
            if(ModelState.IsValid)
            {
                var newCall = new Call()
                {
                    Address = model.Address,
                    CallTime = DateTime.Now,
                    Category = model.SelectedCategory,
                    Reason = model.Reason
                };
                int callId = _callProvider.CreateCall(newCall);

                return RedirectToAction("CallDetails", new{ id = callId});
            }
            return View();
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

            var categories = _callProvider.GetCategories();
            model.Categories = categories.Select(category => new SelectListItem()
            {
                Value = category,
                Text = category
            });
            return View(model);
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

        [HttpGet]
        public ActionResult CloseCall(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var call = _callProvider.GetCallById((int)id);
            var callResponses = _callResponseProvider.GetCallResponsesForCall((int)id)
                .Where(callResponse => callResponse.IsActive == true);
            if (!callResponses.Any())
            {
                var model = new CallEditModel()
                {
                    Id = call.Id,
                    Address = call.Address,
                    CallTime = call.CallTime,
                    Reason = call.Reason,
                    SelectedCategory = call.Category
                };
                return View(model);
            }
            return RedirectToAction("CallDetails", "Call", new { id });
        }

        [HttpPost]
        public ActionResult CloseCall(CallEditModel model)
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
            return View(model);
        }
    }
}