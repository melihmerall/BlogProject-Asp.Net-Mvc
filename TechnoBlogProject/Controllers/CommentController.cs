using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Entity.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager();
        // GET: Comment
        public PartialViewResult CommentList(int id)
        {

            var commentList = _commentManager.commentByBlog(id);

            return PartialView(commentList);
        }
        [HttpGet]
        public PartialViewResult ReplyComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        public RedirectToRouteResult ReplyComment(Comment c)
        {
            c.CommentDate = DateTime.Now;

            _commentManager.CommentAdd(c);
            return RedirectToAction("BlogDetails/" + c.BlogId, "Blog", new { area = "" });
        }
    }
}