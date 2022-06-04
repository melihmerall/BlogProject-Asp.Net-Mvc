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

        public Blog GetById(int id)
        {
            return _repoblog.GetById(id);
        }

        public List<Blog> GetBlogByIdList(int id)
        {
            return _repoblog.List(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            return _repoblog.List(x => x.AuthorId == id);
        }
        
        public List<Blog> GetBlogByCategoryId(int id)
        {
            return _repoblog.List(x => x.CategoryId == id);
        }



        public void DeleteBlog(int p)
        {
            Blog blog = _repoblog.Find(x => x.BlogId == p);
             _repoblog.Delete(blog);
        }

        // Change Status - false or true
        public void CommentStatusChangeToFalse(int id)
        {
            Blog blog = _repoblog.Find(x => x.BlogId == id);
            blog.BlogStatus = false;
            _repoblog.Update(blog);
        }
        public void CommentStatusChangeToTrue(int id)
        {
            Blog blog = _repoblog.Find(x => x.BlogId == id);
            blog.BlogStatus = true;
            _repoblog.Update(blog);


        }
        public List<Blog> GetList()
        {
            return _repoblog.GetList();
        }

        public void TAdd(Blog t)
        {
            _repoblog.Add(t);
        }

        public void TRemove(Blog t)
        {

        }

        public void TUpdate(Blog t)
        {
            _repoblog.Update(t);
        }
    }

}
