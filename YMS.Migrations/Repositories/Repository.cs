using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using YMS.Migrations.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YMS.Migrations.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal AppDbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? take = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                if (take == null)
                    return await orderBy(query).ToListAsync();
                else
                    return await orderBy(query).Take(take.Value).ToListAsync();
            }
            else
            {
                if (take == null)

                    return await query.ToListAsync();
                else
                    return await query.Take(take.Value).ToListAsync();
            }
        }

        public async Task<TEntity> GetById(int id, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            query = query.Where(e => EF.Property<int>(e, "Id") == id);

            foreach (var includeProperty in includeProperties.
                Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetById(Guid id, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            query = query.Where(e => EF.Property<Guid>(e, "Id") == id);

            foreach (var includeProperty in includeProperties.
                Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}
