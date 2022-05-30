using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace TechnoBlogProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager _blogManager = new BlogManager();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult BlogList(int pageValue = 1)
        {

            var bloglist = _blogManager.GetAll().ToPagedList(pageValue, 10);



            return PartialView(bloglist);
        }

        public PartialViewResult FeaturedPost()
        {

            //1.post
            var postTitle1 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogTitle).FirstOrDefault();

            var postImage1 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate1 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.blogDate1 = blogeDate1;

            //2.post
            var postTitle2 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1009)
                .Select(y => y.BlogTitle).FirstOrDefault();

            var postImage2 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1009)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate2 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1009)
                .Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogDate2 = blogeDate2;

            //3.post
            var postTitle3 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1014)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1014)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate3 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1014)
                .Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogDate3 = blogeDate3;

            //4.post
            var postTitle4 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate4 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogDate4 = blogeDate4;

            //4.post
            var postTitle5 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1013)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1013)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate5 = _blogManager.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1013)
                .Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogDate5 = blogeDate5;

            return PartialView();
        }

        public PartialViewResult OtherFeaturedPost()
        {
            // viewbag

            ViewBag.value = "Selam";

            return PartialView();
        }


        public ActionResult BlogDetails()
        {

            return View();
        }

        public PartialViewResult BlogCover(int id)

        {
            ViewBag.id = id;
            var blogDetailsList = _blogManager.GetBlogByIdList(id);
            return PartialView(blogDetailsList);

        }

        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = _blogManager.GetBlogByIdList(id);
            return PartialView(blogDetailsList);

        }

        public ActionResult BlogByCategory(int id)
        {
            var blogListByCategory = _blogManager.GetBlogByCategoryId(id);
            var CategoryName = _blogManager.GetBlogByCategoryId(id).Select(y => y.Category.CategoryName)
                .FirstOrDefault();
            ViewBag.CategoryName = CategoryName;

            var CategoryDesc = _blogManager.GetBlogByCategoryId(id).Select(y => y.Category.CategoryDescription)
                .FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(blogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var bloglist = _blogManager.GetAll();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = _blogManager.GetAll();
            return View(bloglist);
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
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager commentyManager = new CommentManager();
            var commentList = commentyManager.CommentByBlog(id);
            return View(commentList);
        }



        // Status Change
        public ActionResult StatusChangeToTrue(int id)
        {
            _blogManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            _blogManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminBlogList");
        }


    }
}