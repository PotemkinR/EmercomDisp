using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.CallResponses;
using EmercomDisp.Web.Models.Equipment_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize(Roles ="User")]
    public class CallResponseController : Controller
    {
        private readonly ICallResponseProvider _callResponseProvider;
        private readonly IEquipmentProvider _equipmentProvider;

        public CallResponseController(ICallResponseProvider callResponseProvider,
            IEquipmentProvider equipmentProvider)
        {
            _callResponseProvider = callResponseProvider ?? throw new ArgumentNullException("Call Response Provider");
            _equipmentProvider = equipmentProvider ?? throw new ArgumentNullException("Equipment Provider");
        }

        [ChildActionOnly]
        public PartialViewResult CallResponseList(int id)
        {
            var model = new CallResponseListModel()
            {
                CallId = id,
                CallResponses = _callResponseProvider.GetCallResponsesForCall(id)
            };
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult EditCallResponse(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            var callResponse = _callResponseProvider.GetCallResponseById((int)id);
            if(callResponse.Id != 0)
            {
                var model = new CallResponseEditModel()
                {
                    Id = callResponse.Id,
                    IncidentId = callResponse.IncidentId,
                    TransferTime = callResponse.TransferTime,
                    ArriveTime = callResponse.ArriveTime,
                    FinishTime = callResponse.FinishTime,
                    ReturnTime = callResponse.ReturnTime,
                    BrigadeName = callResponse.BrigadeName
                };

                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCallResponse(CallResponseEditModel model)
        {
            if (ModelState.IsValid)
            {
                var callResponse = new CallResponse()
                {
                    Id = model.Id,
                    TransferTime = model.TransferTime,
                    ArriveTime = model.ArriveTime,
                    FinishTime = model.FinishTime,
                    ReturnTime = model.ReturnTime,                   
                };
                _callResponseProvider.UpdateCallResponse(callResponse);
                return RedirectToAction("CallDetails", "Call", new { id = model.IncidentId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditEquipmentList(int? id, int? callId)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var selectedEquipmentList = _equipmentProvider.GetEquipmentByCallResponseId((int)id);
            var equipmentList = _equipmentProvider.GetEquipment();

            var model = new EditEquipmentListModel();
            var modelList = new List<EquipmentSelectable>();

            foreach (var item in equipmentList)
            {
                var equipmentItem = new EquipmentSelectable()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                equipmentItem.IsSelected = (selectedEquipmentList.Any(x => x.Id == item.Id)) ? true : false;
                modelList.Add(equipmentItem);
            }
            model.Equipment = modelList;
            model.CallId = (int)callId;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEquipmentList(EditEquipmentListModel model)
        {
            var equipmentList = model.Equipment;
            var updatedEquipmentList = new List<Equipment>();
            foreach(var item in equipmentList)
            {
                if (item.IsSelected)
                {
                    updatedEquipmentList.Add(
                        new Equipment()
                        {
                            Id = item.Id,
                            Name = item.Name
                        });
                }
            }
            _equipmentProvider.UpdateEquipmentList(updatedEquipmentList, model.CallId);

            return RedirectToAction("CallDetails", "Call",new { id = model.CallId });
        }

        [HttpGet]
        public ActionResult DeleteCallResponse(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var callResponse = _callResponseProvider.GetCallResponseById((int)id);
            if (callResponse.Id != 0)
            {
                var model = new CallResponseDeleteModel()
                {
                    CallResponse = callResponse
                };

                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteCallResponse(int id)
        {
            _callResponseProvider.DeleteCallResponse(id);
            return RedirectToAction("CallList", "CallList");
        }
    }
}