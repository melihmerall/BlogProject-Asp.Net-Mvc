using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
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

        public ActionResult BlogByCategory()
        {
            return View();
        }

    }
}