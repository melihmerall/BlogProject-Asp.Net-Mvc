using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CommentManager:ICommentService
    {
        EfEntityRepositoryBase<Comment, BlogContext> repoComment = new EfEntityRepositoryBase<Comment, BlogContext>();


    




        public List<Comment> CommentList()
        {
            return repoComment.GetList();
        }


        public List<Comment> CommentByBlog(int id)
        {
            return repoComment.List(x => x.BlogId == id);
        }

        public List<Comment> CommentByStatusTrue()
        {
            return repoComment.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return repoComment.List(x => x.CommentStatus == false);
        }

        public void CommentAdd(Comment c)
        {
 
             repoComment.Add(c);
        }
        public void CommentStatusChangeToFalse(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentId == id);
            comment.CommentStatus = false;
            repoComment.Update(comment);


        }
        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentId == id);
            comment.CommentStatus = true;
            repoComment.Update(comment);
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Commentremove(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void CommentUpdate(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
