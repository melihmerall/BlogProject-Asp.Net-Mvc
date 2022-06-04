using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubscribeService
    {
        List<Subscribe> GetList();

        Subscribe GetById(int id);
        void SubscribeAdd(Subscribe subscribe);
        void SubscribeRemove(Subscribe subscribe);
        void SubscribeUpdate(Subscribe subscribe);
    }
}
