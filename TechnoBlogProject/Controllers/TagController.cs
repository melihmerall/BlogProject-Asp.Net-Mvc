using Business.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnoBlogProject.Controllers
{
    public class TagController : Controller
    {
        TagManager tagManager = new TagManager();
        // GET: Tag
        
        public ActionResult Index()
        {
            return View();
        }
        [Route("adminTagList")]
        public ActionResult TagList()
        {
            var tagList = tagManager.GetAll();
            return View(tagList);
        }
        [HttpGet]
        [Route("addNewTag")]
        public ActionResult AddNewTag()
        {
            return View();
        }
        [HttpPost]
          [Route("addNewTag")]
        public ActionResult AddNewTag(Tag t)
        {
            tagManager.AddTag(t);
            return RedirectToAction("TagList");
        }


        [HttpGet]
        public ActionResult TagEdit(int id)
        {
            var tag = tagManager.GetById(id);
            return View(tag);
        }
        [HttpPost]
        public ActionResult TagEdit(Tag t)
        {
            tagManager.UpdateAuthor(t);
            return RedirectToAction("TagList");
        }
        [AllowAnonymous]
        public PartialViewResult MainTagList()
        {
               
                var tagList = tagManager.GetAll();
                return PartialView(tagList);
            
        }
    }
}