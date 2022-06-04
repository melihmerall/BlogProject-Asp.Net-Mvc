using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace TechnoBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author a)
        {
            BlogContext _blogContext = new BlogContext();
            var userData = _blogContext.Authors.FirstOrDefault(x => x.AuthorMail == a.AuthorMail && x.AuthorPassword == a.AuthorPassword);
            if (userData != null)
            {
                FormsAuthentication.SetAuthCookie(userData.AuthorMail, false);
                Session["AuthorMail"] = userData.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }

            
           

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            BlogContext _blogContext = new BlogContext();
            var adminInfo = _blogContext.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
                Session["UserName"] = adminInfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }




        }
    }
}