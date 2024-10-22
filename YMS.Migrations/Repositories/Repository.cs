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

        public async Task<(IEnumerable<TEntity> items, int totalCount)> Get(
        Func<IQueryable<TEntity>, IQueryable<TEntity>> filter = null,
        string orderByField= "CreatedDate",
        bool isDescending=true,
        string includeProperties = "",
        int pageNumber = 1,
        int pageSize = 10)
        {
            IQueryable<TEntity> query = dbSet;

            // Apply filter
            if (filter != null)
            {
                query = filter(query);
            }

            // Include related entities
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(orderByField))
            {
                var fields = orderByField.Split('.');
                var parameter = Expression.Parameter(typeof(TEntity), "x");
                Expression property = parameter;

                foreach (var field in fields)
                {
                    property = Expression.PropertyOrField(property, field);
                }

                var lambda = Expression.Lambda(property, parameter);

                var methodName = isDescending ? "OrderByDescending" : "OrderBy";
                var resultExpression = Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new Type[] { typeof(TEntity), property.Type },
                    query.Expression,
                    Expression.Quote(lambda));

                query = query.Provider.CreateQuery<TEntity>(resultExpression);
            }

            var totalCount = await query.CountAsync();

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return (items, totalCount);
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
