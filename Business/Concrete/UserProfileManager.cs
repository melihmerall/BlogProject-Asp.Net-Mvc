using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace Business.Concrete
{
    public class UserProfileManager
    {
        EfEntityRepositoryBase<Author, BlogContext> repouser = new EfEntityRepositoryBase<Author, BlogContext>();
        EfEntityRepositoryBase<Blog, BlogContext> repoUserBlog = new EfEntityRepositoryBase<Blog, BlogContext>();
        public List<Author> GetBlogByAuthorMail(string p)
        {
            return repouser.List(x => x.AuthorMail == p);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoUserBlog.List(x => x.AuthorId == id);
        }
        public void UpdateAuthor(Author author)
        {
            repouser.Update(author);
        }
    }
}
