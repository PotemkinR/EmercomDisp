﻿using EmercomDisp.BLL.Providers;
using EmercomDisp.Web.Models.CategoryViewModels;
using System.Web.Mvc;

namespace EmercomDisp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICallProvider _callProvider;

        public CategoryController(ICallProvider callProvider)
        {
            _callProvider = callProvider;
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