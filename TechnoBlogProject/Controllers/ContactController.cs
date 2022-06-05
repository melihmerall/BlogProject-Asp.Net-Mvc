using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Entity.Concrete;

namespace TechnoBlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager();
        [AllowAnonymous]
        
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]

        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            contactManager.ContactAdd(c);
            return View();
        }

        public ActionResult MessageBox()
        {
            var messageList = contactManager.GetList();
            return View(messageList);
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetContactDetails(id);
            return View(contact);
        }
    }
}