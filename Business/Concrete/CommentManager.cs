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
    public class CommentManager
    {
        EfEntityRepositoryBase<Comment, BlogContext> _repoComment = new EfEntityRepositoryBase<Comment, BlogContext>();

        public List<Comment> commentList()
        {
            return _repoComment.GetList();
        }

        public List<Comment> commentByBlog(int id)
        {
            return _repoComment.List(x => x.BlogId == id);
        }

        public int CommentAdd(Comment c)
        {
            if (c.CommentText.Length <= 4 || c.CommentText.Length >= 300 || c.UserName == "" ||
                c.Mail == "" || c.UserName.Length <= 5)
            {
                return -1;
            }
            return _repoComment.Add(c);
        }
    }
}
