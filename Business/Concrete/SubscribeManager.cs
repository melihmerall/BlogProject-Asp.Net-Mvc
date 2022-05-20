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
        public int SubscribeAdd(Subscribe mail)
        {
            if (mail.Mail.Length <= 10 || mail.Mail.Length >= 50)
            {
                return -1;
            }

            return repoSubscribeMail.Add(mail);
        }
    }
}
