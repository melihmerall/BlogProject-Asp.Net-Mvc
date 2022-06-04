using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using FluentValidation.Results;

namespace TechnoBlogProject.Controllers
{
    
    public class UserController : Controller
    {
        
        // GET: AuthorLogin
        UserProfileManager profileManager = new UserProfileManager();
        BlogManager _blogManager = new BlogManager();
       
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult UserActivity(string mail)
        {
           
            mail = (string)Session["AuthorMail"];
            var profileValues = profileManager.GetBlogByAuthorMail(mail);
            return PartialView(profileValues);
        }

        public ActionResult UpdateUserProfile(Author author)
        {
            profileManager.UpdateAuthor(author);
            return RedirectToAction("Index");
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["AuthorMail"];
            BlogContext c = new BlogContext();
            int id = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = profileManager.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            BlogContext blogContext = new BlogContext();
            List<SelectListItem> values = (from x in blogContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in blogContext.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            Blog blog = _blogManager.GetById(id);
            return View(blog);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateBlog(Blog b)
        {
            BlogContext blogContext = new BlogContext();
            List<SelectListItem> values = (from x in blogContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in blogContext.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(b);
            if (results.IsValid)
            {
                _blogManager.TUpdate(b);
                return RedirectToAction("BlogList","User");
            }
            else
            {
                foreach (var value in results.Errors)
                {
                    ModelState.AddModelError(value.PropertyName, value.ErrorMessage);
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            // Dropdown list. Solid hale gelecek.
            BlogContext blogContext = new BlogContext();
            List<SelectListItem> values = (from x in blogContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in blogContext.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddNewBlog(Blog blog)
        {
            _blogManager.TAdd(blog);
            return RedirectToAction("BlogList");
        }

        public ActionResult StatusChangeToTrue(int id)
        {
            _blogManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("BlogList","User");
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            _blogManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("BlogList","User");
        }


        // LogOut from author manager page.
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
        public ActionResult UserProfile(string p)
        {
            p = (string)Session["AuthorMail"];
            BlogContext c = new BlogContext();
            int id = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorId).FirstOrDefault();
            var users = profileManager.GetUserById(id);
            return View(users);
        }

    }
}