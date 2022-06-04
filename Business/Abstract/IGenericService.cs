using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        T GetById(int id);
        void TAdd(T t);
        void TRemove(T t);
        void TUpdate(T t);
    }
}
