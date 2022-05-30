using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Business.Concrete;
using Entity.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager _blogManager = new BlogManager();
        AuthorManager _authorManager = new AuthorManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = _blogManager.GetBlogByIdList(id);
            return PartialView(authorDetails);
        }

        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorId = _blogManager.GetAll().Where(x => x.BlogId == id).Select(y => y.AuthorId)
                .FirstOrDefault();

            var authorBlogs = _blogManager.GetBlogByAuthorId(blogAuthorId);

            return PartialView(authorBlogs);
        }

        public ActionResult AuthorList()
        {
            var authorList = _authorManager.GetAll();
            return View(authorList);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAuthor(Author a)
        {
            _authorManager.AddAuthorBl(a);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = _authorManager.GetById(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            _authorManager.UpdateAuthor(author);
            return RedirectToAction("AuthorList");
        }
    }
}