using EmercomDisp.Model.Models;
using EmercomDisp.Web.Models.CategoryViewModels;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class CategoryController : Controller
    {       
        public PartialViewResult Category()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = Enum.GetNames(typeof(UrgencyEnum))
            };
            return PartialView(model);
        }
    }
}