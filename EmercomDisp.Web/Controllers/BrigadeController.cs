using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.Brigades;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class BrigadeController : Controller
    {
        private readonly IBrigadeProvider _brigadeProvider;

        public BrigadeController(IBrigadeProvider brigadeProvider)
        {
            _brigadeProvider = brigadeProvider ?? throw new ArgumentNullException("Brigade Provider");
        }

        public ActionResult BrigadeList()
        {
            var model = new BrigadeListModel()
            {
                Brigades = _brigadeProvider.GetBrigades()
            };
            return View(model);
        }

        public ActionResult BrigadeMembersList()
        {
            var model = new BrigadeMembersListModel()
            {
                BrigadeMembers = _brigadeProvider.GetBrigadeMembers()
            };
            return View(model);
        }
        
        [HttpGet]
        public ActionResult EditBrigade(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var brigade = _brigadeProvider.GetBrigadeById((int)id);

            if(brigade != null)
            {
                var model = new BrigadeModel()
                {
                    Id = brigade.Id,
                    BrigadeName = brigade.Name
                };
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditBrigade(BrigadeModel model)
        {
            if (ModelState.IsValid)
            {
                var updatedBrigade = new Brigade
                {
                    Id = model.Id,
                    Name = model.BrigadeName
                };

                _brigadeProvider.UpdateBrigade(updatedBrigade);
            }
            return RedirectToAction("BrigadeList");
        }

        [HttpGet]
        public ActionResult CreateBrigade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBrigade(BrigadeModel model)
        {
            if (ModelState.IsValid)
            {
                var newBrigade = new Brigade
                {
                    Name = model.BrigadeName
                };
                _brigadeProvider.CreateBrigade(newBrigade);

                return RedirectToAction("BrigadeList");
            }
            return View();
        }

        public ActionResult DeleteBrigade(int id)
        {
            _brigadeProvider.DeleteBrigade(id);
            return RedirectToAction("BrigadeList");
        }

        [HttpGet]
        public ActionResult EditBrigadeMember(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var brigadeMember = _brigadeProvider.GetBrigadeMemberById((int)id);
            var brigades = _brigadeProvider.GetBrigades();
            if (brigadeMember.Name != null)
            {
                var model = new BrigadeMemberEditModel()
                {
                    Id = brigadeMember.Id,
                    SelectedBrigadeName = brigadeMember.BrigadeName,
                    Name = brigadeMember.Name,
                    BrigadeName = brigadeMember.BrigadeName,
                    Brigades = brigades.Select(brigade => new SelectListItem
                    {
                        Value = brigade.Name,
                        Text = brigade.Name
                    })
                };
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditBrigadeMember(BrigadeMemberEditModel model)
        {          
            if (ModelState.IsValid)
            {
                var updatedBrigadeMember = new BrigadeMember
                {
                    Id = model.Id,
                    Name = model.Name,
                    BrigadeName = model.SelectedBrigadeName
                };

                _brigadeProvider.UpdateBrigadeMember(updatedBrigadeMember);
            }
            return RedirectToAction("BrigadeMembersList");
        }

        public ActionResult DeleteBrigadeMember(int id)
        {
            _brigadeProvider.DeleteBrigadeMember(id);
            return RedirectToAction("BrigadeMembersList");
        }

        [HttpGet]
        public ActionResult CreateBrigadeMember()
        {
            var brigades = _brigadeProvider.GetBrigades();
            var model = new BrigadeMemberCreateModel()
            {
                Brigades = brigades.Select(brigade => new SelectListItem
                {
                    Value = brigade.Name,
                    Text = brigade.Name
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateBrigadeMember(BrigadeMemberCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var newBrigadeMember = new BrigadeMember
                {
                    Name = model.Name,
                    BrigadeName = model.SelectedBrigadeName
                };
                _brigadeProvider.CreateBrigadeMember(newBrigadeMember);
            }
            return RedirectToAction("BrigadeMembersList");
        }
    }
}