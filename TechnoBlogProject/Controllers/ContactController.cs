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
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            contactManager.ContactAdd(c);
            return View();
        }

        public ActionResult MessageBox()
        {
            var messageList = contactManager.GetAll();
            return View(messageList);
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetContactDetails(id);
            return View(contact);
        }
    }
}