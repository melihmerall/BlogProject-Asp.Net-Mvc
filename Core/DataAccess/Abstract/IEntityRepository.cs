﻿using System;
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
        T Get(Expression<Func<T, bool>> filter);
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);

        List<T> List(Expression<Func<T, bool>> filter);




    }
}
