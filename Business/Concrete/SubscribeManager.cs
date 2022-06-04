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
    public class SubscribeManager : ISubscribeService
    {
        EfEntityRepositoryBase<Subscribe, BlogContext> repoSubscribeMail = new EfEntityRepositoryBase<Subscribe, BlogContext>();

        public Subscribe GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subscribe> GetList()
        {
            throw new NotImplementedException();
        }

        public void SubscribeAdd(Subscribe mail)
        {


             repoSubscribeMail.Add(mail);
        }

        public void SubscribeRemove(Subscribe subscribe)
        {
            throw new NotImplementedException();
        }

        public void SubscribeUpdate(Subscribe subscribe)
        {
            throw new NotImplementedException();
        }

        void ISubscribeService.SubscribeAdd(Subscribe subscribe)
        {
            throw new NotImplementedException();
        }
    }
}
