using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;

namespace TechnoBlogProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager _categoryManager = new CategoryManager();
        public ActionResult Index()
        {
            var categoryValues = _categoryManager.GetList();
            return View(categoryValues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = _categoryManager.GetList();
            return PartialView(categoryValues);
        }
        [Route("adminCategoryList")]
        public ActionResult AdminCategoryList()
        {
            var categoryList = _categoryManager.GetList();
            return View(categoryList);
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            _categoryManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            _categoryManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCategoryList");
        }


        [HttpGet]
        [Route("AddNewCategory")]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        [Route("AddNewCategory")]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if (results.IsValid)
            {
                _categoryManager.TAdd(c);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]

        public ActionResult CategoryEdit(int id)
        {
            Category category = _categoryManager.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                _categoryManager.TUpdate(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

    }
}