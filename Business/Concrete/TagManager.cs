using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TagManager
    {

        EfEntityRepositoryBase<Tag, BlogContext> _repoTag = new EfEntityRepositoryBase<Tag, BlogContext>();
        BlogContext blogContext = new BlogContext();
        public List<Tag> GetAll()
        {
            return _repoTag.GetList();
        }
        public Tag GetById(int id)
        {
            return _repoTag.GetById(id);
        }

        public void AddTag(Tag tag)
        {


             _repoTag.Add(tag);
        }
        public void UpdateAuthor(Tag tag)
        {
            _repoTag.Update(tag);
        }

    }
}
