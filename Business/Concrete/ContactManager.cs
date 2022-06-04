using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ContactManager:IContactService
    {
        EfEntityRepositoryBase<Contact, BlogContext> repoContact = new EfEntityRepositoryBase<Contact, BlogContext>();

        public void ContactAdd(Contact c)
        {
           
             repoContact.Add(c);
        }

        public Contact GetById(int id)
        {
            return repoContact.GetById(id);
        }

        public Contact GetContactDetails(int id)
        {
            return repoContact.Find(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return repoContact.GetList();
        }

        public void TAdd(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TRemove(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
