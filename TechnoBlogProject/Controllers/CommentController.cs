using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Entity.Concrete;
using PagedList.Mvc;
using PagedList;

namespace TechnoBlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager();
        // GET: Comment

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            

            var commentList = commentManager.CommentByBlog(id);

            return PartialView(commentList);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult ReplyComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public RedirectToRouteResult ReplyComment(Comment c)
        {
            c.CommentDate = DateTime.Now;

            commentManager.CommentAdd(c);
            return RedirectToAction("BlogDetails/" + c.BlogId, "article", new { area = "" });
        }
        [Route("adminCommentListTrue")]
        public ActionResult AdminCommentListTrue(int pageValue = 1)
        {
          
            var commentList = commentManager.CommentByStatusTrue().ToPagedList(pageValue, 10);

            return View(commentList);
        }

        public ActionResult StatusChangeToFalse(int id)
        {

            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        [Route("adminCommentListFalse")]
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