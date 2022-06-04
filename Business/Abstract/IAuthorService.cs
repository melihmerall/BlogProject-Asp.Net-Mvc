using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();

        Author GetById(int id);
        void AddAuthorBl(Author author);
        //void AuthorRemove(Author author);
        void UpdateAuthor(Author author);
    }
}
