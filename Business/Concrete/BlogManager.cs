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

        public int BlogAdd(Blog blog)
        {
            if (blog.BlogTitle == "" || blog.BlogImage == "" || blog.BlogContent == "" || blog.BlogTitle == "" ||
                blog.BlogTitle.Length <= 5 || blog.BlogContent.Length <= 200)
            {
                return -1;
            }

            return _repoblog.Add(blog);
        }

        public int DeleteBlog(int p)
        {
            Blog blog = _repoblog.Find(x => x.BlogId == p);
            return _repoblog.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _repoblog.Update(blog);
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

    }

}
