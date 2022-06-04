using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITagService
    {
        List<Tag> GetList();

        Tag GetById(int id);
        void AboutAdd(Tag contact);
        void AboutRemove(Tag contact);
        void AboutUpdate(Tag contact);
    }
}
