using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        EfEntityRepositoryBase<Author, BlogContext> repoAuthor = new EfEntityRepositoryBase<Author, BlogContext>();

        // Get all author list
        public List<Author> GetAll()
        {
            return repoAuthor.GetList();
        }

        public Author GetById(int id)
        {
            return repoAuthor.GetById(id);
        }

        //Add new author
        public void AddAuthorBl(Author author)
        {


             repoAuthor.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            repoAuthor.Update(author);
        }
    }
}
