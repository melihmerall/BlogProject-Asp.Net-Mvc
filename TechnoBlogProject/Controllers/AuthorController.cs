using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Business.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        private BlogManager _blogManager = new BlogManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = _blogManager.GetBlogByIdList(id);
            return PartialView(authorDetails);
        }

        public PartialViewResult AuthorPopularPost()
        {
            return PartialView();
        }
    }
}