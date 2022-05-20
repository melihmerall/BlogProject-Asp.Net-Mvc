using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace Business.Concrete
{
    public class BlogManager : IBlogService

    {
        EfEntityRepositoryBase<Blog, BlogContext> _repoblog = new EfEntityRepositoryBase<Blog, BlogContext>();
        public List<Blog> GetAll()
        {
            return _repoblog.GetList();
        }

        public List<Blog> GetBlogByIdList(int id)
        {
            return _repoblog.List(x => x.BlogId == id);
        }



    }

}
