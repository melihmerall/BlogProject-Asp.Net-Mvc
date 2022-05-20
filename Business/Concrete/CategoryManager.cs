using Business.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService

    {
        EfEntityRepositoryBase<Category, BlogContext> _repoCategory = new EfEntityRepositoryBase<Category, BlogContext>();

        public List<Category> GetAll()
        {
            return _repoCategory.GetList();
        }
    }
}
