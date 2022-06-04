using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> CommentList();

        Comment GetById(int id);
        void CommentAdd(Comment  comment);
        void Commentremove(Comment comment);
        void CommentUpdate(Comment comment);
    }
}
