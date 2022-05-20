using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Entity.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class MailSubscribeController : Controller
    {
        SubscribeManager subscribeManager = new SubscribeManager();
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(Subscribe m)
        {
            subscribeManager.SubscribeAdd(m);
            return PartialView();
        }
    }
}