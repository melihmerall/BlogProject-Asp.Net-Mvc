using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using PagedList.Mvc;
using PagedList;
using System.IO;

using FluentValidation.Results;
using Business.ValidationRules;

namespace TechnoBlogProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager _blogManager = new BlogManager();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int pageValue = 1)
        {

            var bloglist = _blogManager.GetList().ToPagedList(pageValue, 10);

            var blogCount = _blogManager.GetList().Select(y => y.BlogId).Count();

            ViewBag.blogCount = blogCount;

            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public ActionResult AllBlogList(int pageValue = 1)
        {
            var allBlogList = _blogManager.GetList().ToPagedList(pageValue, 9);
            return View(allBlogList);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {

            // Due to the main page setup, I had to bring the posts separately. Brings the newest post from the selected categories.
            //I could call it with foreach on the view side, but I couldn't get the view I wanted.

            //1.post
            var postTitle1 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1 )
                .Select(y => y.BlogTitle).FirstOrDefault();

            var postImage1 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate1 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId1 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory1 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.Category.CategoryName).FirstOrDefault();

            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.blogDate1 = blogeDate1;
            ViewBag.blogPostId1 = blogPostId1;
            ViewBag.blogCategory1 = blogCategory1;

            //2.post
            var postTitle2 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogTitle).FirstOrDefault();

            var postImage2 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate2 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId2 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory2 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 2)
                .Select(y => y.Category.CategoryName).FirstOrDefault();

            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogDate2 = blogeDate2;
            ViewBag.blogPostId2 = blogPostId2;
            ViewBag.blogCategory2 = blogCategory2;

            //3.post
            var postTitle3 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate3 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId3 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory3 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 3)
               .Select(y => y.Category.CategoryName).FirstOrDefault();

            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogDate3 = blogeDate3;
            ViewBag.blogPostId3 = blogPostId3;
            ViewBag.blogCategory3 = blogCategory3;


            //4.post
            var postTitle4 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 9)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 9)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate4 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 9)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId4 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 9)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory4 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 9)
               .Select(y => y.Category.CategoryName).FirstOrDefault();

            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogDate4 = blogeDate4;
            ViewBag.blogPostId4 = blogPostId4;
            ViewBag.blogCategory4 = blogCategory4;

            //5.post
            var postTitle5 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 11)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 11)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate5 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 11)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId5 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 11)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory5 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 11)
                .Select(y => y.Category.CategoryName).FirstOrDefault();

            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogDate5 = blogeDate5;
            ViewBag.blogPostId5 = blogPostId5;
            ViewBag.blogCategory5 = blogCategory5;

            //6.post
            var postTitle6 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 10)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage6 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 10)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate6 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 10)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId6 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 10)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory6 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 10)
                .Select(y => y.Category.CategoryName).FirstOrDefault();


            ViewBag.postTitle6 = postTitle6;
            ViewBag.postImage6 = postImage6;
            ViewBag.blogDate6 = blogeDate6;
            ViewBag.blogPostId6 = blogPostId6;
            ViewBag.blogCategory6 = blogCategory6;


            //7. post

            var postTitle7 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postImage7 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogeDate7 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogPostId7 = _blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogId).FirstOrDefault();
            var blogCategory7 = _blogManager.GetList().OrderBy(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.Category.CategoryName).FirstOrDefault();

            ViewBag.postTitle7 = postTitle7;
            ViewBag.postImage7 = postImage7;
            ViewBag.blogDate7 = blogeDate7;
            ViewBag.blogPostId7 = blogPostId7;
            ViewBag.blogCategory7 = blogCategory7;

            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost(int pageValue = 1)
        {
            // viewbag , 10 farklı blog çektir. rate oranına göre ve true olanları.

            var featuredPosts = _blogManager.GetList().ToPagedList(pageValue, 30).OrderByDescending(c => c.BlogId);



            return PartialView(featuredPosts);
        }
        [AllowAnonymous]
        public PartialViewResult PopularPost(int pageValue = 1)
        {
            var popularPosts = _blogManager.GetList().ToPagedList(pageValue, 10).OrderByDescending(c => c.BlogId);
            return PartialView(popularPosts);   
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {

            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)

        {
            ViewBag.id = id;
            var blogDetailsList = _blogManager.GetBlogByIdList(id);
            return PartialView(blogDetailsList);

        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = _blogManager.GetBlogByIdList(id);
            return PartialView(blogDetailsList);

        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {

            int pageNum = 1;


            var blogListByCategory = _blogManager.GetBlogByCategoryId(id).ToPagedList(pageNum, 30);



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
            var bloglist = _blogManager.GetList();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = _blogManager.GetList();
            return View(bloglist);
        }

        [Authorize(Roles ="A")]
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

        [HttpPost]
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
            if(results.IsValid)
            {
                _blogManager.TAdd(b);
                return RedirectToAction("AdminBlogList");
            }
            else
            {
                foreach(var value in results.Errors)
                {
                    ModelState.AddModelError(value.PropertyName, value.ErrorMessage);
                }
            }

            return View();
           
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
                _blogManager.TUpdate(b);
                return RedirectToAction("AdminBlogList");
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

        // Tagları çekiyorum.


        public ActionResult AuthorBlogList(int id)
        {

            var blogs = _blogManager.GetBlogByAuthorId(id);
            return View(blogs);
        }
       
    }
}