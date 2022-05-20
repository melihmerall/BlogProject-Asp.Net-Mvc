using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Business.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Footer()
        {
            var aboutContentList = aboutManager.GetAll();
            return PartialView(aboutContentList);
        }

        public PartialViewResult WhoIsTeam()
        {
            return PartialView();
        }
    }
}