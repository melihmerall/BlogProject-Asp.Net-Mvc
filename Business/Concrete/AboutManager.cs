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
    public class AboutManager : IAboutService
    {
        EfEntityRepositoryBase<About, BlogContext> repoAbout = new EfEntityRepositoryBase<About, BlogContext>();
        public List<About> GetAll()
        {
            return repoAbout.GetList();
        }
        public void AboutUpdate(About about)
        {
            repoAbout.Update(about);
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void AboutAdd(About about)
        {
            throw new NotImplementedException();
        }

        public void AboutRemove(About about)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
