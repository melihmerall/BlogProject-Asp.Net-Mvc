using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Business.Concrete;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using PagedList;

namespace TechnoBlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager _blogManager = new BlogManager();
        AuthorManager _authorManager = new AuthorManager();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = _blogManager.GetBlogByIdList(id);
            return PartialView(authorDetails);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            int pageValue = 1;
            
            var blogAuthorId = _blogManager.GetList().Where(x => x.BlogId == id).Select(y => y.AuthorId)
                .FirstOrDefault();

            var authorBlogs = _blogManager.GetBlogByAuthorId(blogAuthorId).ToPagedList(pageValue, 8).OrderByDescending(c => c.BlogId);

            return PartialView(authorBlogs);
        }
        [Route("authorList")]
        public ActionResult AuthorList()
        {
            var authorList = _authorManager.GetAll();
            return View(authorList);
        }
        [HttpGet]
        [Route("addauthor")]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        [Route("addauthor")]
        public ActionResult AddAuthor(Author a)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(a);
            if (results.IsValid)
            {
                if (Request.Files.Count >= 0)
                {


                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string url = "~/Image/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    a.AuthorImage = "/Image/" + fileName + extension;

                }
                _authorManager.AddAuthorBl(a);
                return RedirectToAction("AuthorList");
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
        public ActionResult AuthorEdit(int id)
        {
            Author author = _authorManager.GetById(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author a)
        {


            _authorManager.UpdateAuthor(a);
            return RedirectToAction("AuthorList");
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            _authorManager.AuthorStatusChangeToTrue(id);
            return RedirectToAction("AuthorList");
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            _authorManager.AuthorStatusChangeToFalse(id);
            return RedirectToAction("AuthorList");
        }



    }
}