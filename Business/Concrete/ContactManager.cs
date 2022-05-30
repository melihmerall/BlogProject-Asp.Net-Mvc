using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ContactManager
    {
        EfEntityRepositoryBase<Contact, BlogContext> repoContact = new EfEntityRepositoryBase<Contact, BlogContext>();

        public int ContactAdd(Contact c)
        {
            if (c.Mail == "" || c.Message == "" || c.Name == "" || c.Subject == "" || c.Surname == "" ||
                c.Mail.Length <= 10)
            {
                return -1;
            }
            return repoContact.Add(c);
        }

        public List<Contact> GetAll()
        {
            return repoContact.GetList();
        }

        public Contact GetContactDetails(int id)
        {
            return repoContact.Find(x => x.ContactId == id);
        }
    }
}
