using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Data;
using YMS.Migrations.Entities;

namespace YMS.Migrations.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Customer>> GetAllCustomersByBranchId(Guid? branchId, string? searchKey)
        {
            var items = context.Customers.Where(e => !e.IsDeleted && branchId == null ? true : e.BranchId == branchId).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchKey))
                items = items.Where(e => e.NameEn.Contains(searchKey) || e.Code.Contains(searchKey));
            return items;
        }
    }
}
