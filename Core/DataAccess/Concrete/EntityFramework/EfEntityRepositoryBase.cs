using System.Data.Entity;
using System.Linq;
using Core.DataAccess.Abstract;

using System;
using System.Collections.Generic;

using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public int Add(TEntity entity)
        {
            TContext context = new TContext();

            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            return context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            TContext context = new TContext();

            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();


        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            TContext context = new TContext();

            return context.Set<TEntity>().SingleOrDefault(filter);

        }

        public TEntity GetById(int id)
        {
            TContext context = new TContext();


            return context.Set<TEntity>().Find(id);

        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> filter)
        {
            TContext context = new TContext();

            return context.Set<TEntity>().Where(filter).ToList();
        }


        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            TContext context = new TContext();


            return filter == null ?
                context.Set<TEntity>().ToList() :
                context.Set<TEntity>().Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {
            TContext context = new TContext();

            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();


        }
    }
}
