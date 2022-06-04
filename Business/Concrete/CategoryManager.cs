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
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService

    {
        EfEntityRepositoryBase<Category, BlogContext> _repoCategory = new EfEntityRepositoryBase<Category, BlogContext>();


        public void CommentStatusChangeToFalse(int id)
        {
            Category category = _repoCategory.Find(x => x.CategoryId == id);
            category.CategoryStatus = false;
            _repoCategory.Update(category);
        }
        public void CommentStatusChangeToTrue(int id)
        {
            Category category = _repoCategory.Find(x => x.CategoryId == id);
            category.CategoryStatus = true;
            _repoCategory.Update(category);


        }

        public Category GetById(int id)
        {
            return _repoCategory.GetById(id);
        }

        public List<Category> GetList()
        {
            return _repoCategory.GetList();
        }

        public void TAdd(Category t)
        {
            _repoCategory.Add(t);
        }

        public void TRemove(Category t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            _repoCategory.Update(t);
        }
    }
}
