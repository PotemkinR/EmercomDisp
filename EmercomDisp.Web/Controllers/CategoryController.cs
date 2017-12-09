using EmercomDisp.BLL.Providers;
using EmercomDisp.Web.Models.Categories;
using System;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICallProvider _callProvider;

        public CategoryController(ICallProvider callProvider)
        {
            _callProvider = callProvider ?? throw new ArgumentNullException("CallProvider");
        }
        public PartialViewResult Category()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Categories = _callProvider.GetCategories()
            };

            return PartialView(model);
        }
    }
}