using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

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
        public ActionResult UpdateBlog(Blog blog)
        {
            _blogManager.BlogUpdate(blog);
            return RedirectToAction("BlogList");
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
            _blogManager.BlogAdd(blog);
            return RedirectToAction("BlogList");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }

    }
}