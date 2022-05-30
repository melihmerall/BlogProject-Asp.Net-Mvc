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
        CommentManager commentManager = new CommentManager();
        // GET: Comment
        public PartialViewResult CommentList(int id)
        {

            var commentList = commentManager.CommentByBlog(id);

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

            commentManager.CommentAdd(c);
            return RedirectToAction("BlogDetails/" + c.BlogId, "Blog", new { area = "" });
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentList = commentManager.CommentByStatusTrue();

            return View(commentList);
        }

        public ActionResult StatusChangeToFalse(int id)
        {

            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentList = commentManager.CommentByStatusFalse();

            return View(commentList);
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}