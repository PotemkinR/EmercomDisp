using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Equipment_;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize(Roles ="Admin, Editor")]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentProvider _equipmentProvider;

        public EquipmentController(IEquipmentProvider equipmentProvider)
        {
            _equipmentProvider = equipmentProvider ?? throw new ArgumentNullException("Equipment Provider");
        }

        public ActionResult EquipmentList()
        {
            var equipmentList = _equipmentProvider.GetEquipment();
            var model = new EquipmentListModel()
            {
                EquipmentList = equipmentList
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateEquipment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEquipment(EquipmentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var newEquipment = new Equipment
                {
                    Name = model.Name
                };
                _equipmentProvider.CreateEquipment(newEquipment);

                return RedirectToAction("EquipmentList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditEquipment(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var equipment = _equipmentProvider.GetEquipmentById((int)id);
            if (equipment != null)
            {
                var model = new EquipmentEditModel()
                {
                    Id = equipment.Id,
                    Name = equipment.Name
                };
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditEquipment(EquipmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedEquipment = new Equipment
                {
                    Id = model.Id,
                    Name = model.Name
                };

                _equipmentProvider.UpdateEquipment(updatedEquipment);
                return RedirectToAction("EquipmentList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteEquipment(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var equipment = _equipmentProvider.GetEquipmentById((int)id);

            if(equipment != null)
            {
                var model = new EquipmentDeleteModel()
                {
                    Name = equipment.Name
                };
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteEquipment(int id)
        {
            _equipmentProvider.DeleteEquipment(id);
            return RedirectToAction("EquipmentList");
        }
    }
}