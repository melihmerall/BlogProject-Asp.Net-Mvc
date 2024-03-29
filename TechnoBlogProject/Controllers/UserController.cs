﻿using System;
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
        AuthorManager authorManager = new AuthorManager();  

        [Route("editprofil")]
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
        [Route("updateuserprofile")]
        public ActionResult UpdateUserProfile(Author author)
        {
            profileManager.UpdateAuthor(author);
            return RedirectToAction("Index");
        }
        [Route("bloglist")]
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

        [HttpPost]
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
                if (Request.Files.Count >= 0)
                {

                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string url = "~/Image/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    b.BlogImage = "/Image/" + fileName + extension;

                }
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
        [Route("addnewblog")]
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

        [HttpPost]
        [Route("addnewblog")]
        public ActionResult AddNewBlog(Blog b)
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
                if (Request.Files.Count >= 0)
                {


                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string url = "~/Image/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    b.BlogImage = "/Image/" + fileName + extension;

                }
                _blogManager.TAdd(b);
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

     


        // LogOut from author manager page.
        [Route("LogOut")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
        [Route("userprofile")]
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