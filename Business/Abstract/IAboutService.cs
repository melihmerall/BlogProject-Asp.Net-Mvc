using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        
        About GetById(int id);
        void AboutAdd(About about);
        void AboutRemove(About about);  
        void AboutUpdate(About about);

    }
}
