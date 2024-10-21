using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace YMS.Migrations.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<(IEnumerable<TEntity> items, int totalCount)> Get(
        Func<IQueryable<TEntity>, IQueryable<TEntity>> filter = null,
        string orderByField = null,
        bool isDescending = false,
        string includeProperties = "",
        int pageNumber = 1,
        int pageSize = 10);

        Task<TEntity> GetById(int id, string includeProperties = "");
        Task<TEntity> GetById(Guid id, string includeProperties = "");
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
