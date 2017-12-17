using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Victims;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class VictimsController : Controller
    {
        private readonly IVictimsProvider _victimsProvider;
        private readonly ICallProvider _callProvider;

        public VictimsController(IVictimsProvider victimsProvider,
            ICallProvider callProvider)
        {
            _victimsProvider = victimsProvider ?? throw new ArgumentNullException("Victims Provider");
            _callProvider = callProvider ?? throw new ArgumentNullException("Call Provider");
        }

        public ActionResult VictimsList(int? callId)
        {
            if (callId == null)
            {
                return HttpNotFound();
            }
            var model = new VictimsListModel()
            {
                CallId = (int)callId,
                Victims = _victimsProvider.GetVictimsByIncidentId((int)callId)
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddVictim(int? callId)
        {
            if (callId != null)
            {
                if (_callProvider.GetCallById((int)callId) != null)
                {
                    var model = new VictimModel()
                    {
                        CallId = (int)callId
                    };

                    return View(model);
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult AddVictim(VictimModel model)
        {
            if (ModelState.IsValid)
            {
                var newVictim = new Victim()
                {
                    Name = model.Name,
                    Residence = model.Residence,
                    Age = model.Age
                };

                _victimsProvider.AddVictim(newVictim, model.CallId);
                return RedirectToAction("VictimsList", new { callId = model.CallId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditVictim(int? id, int? callId)
        {
            if (id == null || callId == null)
            {
                return HttpNotFound();
            }

            var victim = _victimsProvider.GetVictimById((int)id);

            if (victim != null)
            {
                var model = new VictimModel()
                {
                    Id = victim.Id,
                    Name = victim.Name,
                    Residence = victim.Residence,
                    Age = victim.Age
                };

                model.CallId = (int)callId;
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditVictim(VictimModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedVictim = new Victim
                {
                    Id = model.Id,
                    Name = model.Name,
                    Residence = model.Residence,
                    Age = model.Age
                };

                _victimsProvider.UpdateVictim(updatedVictim);
            }
            return RedirectToAction("VictimsList",new { callId = model.CallId });
        }

        public ActionResult DeleteVictim(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("VictimsList");
            }

            _victimsProvider.DeleteVictim((int)id);
            return RedirectToAction("VictimsList");
        }
    }
}