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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager();
        public ActionResult Index()
        {
            var aboutContent = aboutManager.GetAll();

            return View(aboutContent);
        }

        public PartialViewResult Footer()
        {
            var aboutContentList = aboutManager.GetAll();
            return PartialView(aboutContentList);
        }

        public PartialViewResult WhoIsTeam()
        {
            AuthorManager _authorManager = new AuthorManager();
            var authorList = _authorManager.GetAll();
            return PartialView(authorList);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList = aboutManager.GetAll();

            return View(aboutList);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About a)
        {
            aboutManager.AboutUpdate(a);
            return RedirectToAction("UpdateAboutList");
        }



    }
}