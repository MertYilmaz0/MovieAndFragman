using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieAndFragman.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieAndFragman.Core.DataAccess.EntityFramework
{
   public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity:class,IEntity
        where TContext:DbContext,new()
    {
        TContext context;
        public EFRepositoryBase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<TContext>();
            ServiceProvider provider = services.BuildServiceProvider();
            context = provider.GetService<TContext>();
        }
        public bool Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            return context.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        public bool Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }

     
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return context.Set<TEntity>().Where(filter).MyInclude(includes).Single();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter==null)
            {
                return context.Set<TEntity>().MyInclude(includes).ToList();
            }
            else
            {
                return context.Set<TEntity>().Where(filter).MyInclude(includes).ToList();
            }
        }
    }
}
