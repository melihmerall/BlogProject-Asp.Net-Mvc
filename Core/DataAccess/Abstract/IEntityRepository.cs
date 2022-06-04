using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        //void ChangeStatus(T entity);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);

        List<T> List(Expression<Func<T, bool>> filter);

        T Find(Expression<Func<T, bool>> filter);




    }
}
