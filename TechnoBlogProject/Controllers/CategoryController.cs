using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager _categoryManager = new CategoryManager();
        public ActionResult Index()
        {
            var categoryValues = _categoryManager.GetAll();
            return View(categoryValues);
        }

        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = _categoryManager.GetAll();
            return PartialView(categoryValues);
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = _categoryManager.GetAll();
            return View(categoryList);
        }
    }
}