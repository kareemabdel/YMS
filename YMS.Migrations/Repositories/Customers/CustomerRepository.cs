using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Data;
using YMS.Migrations.Entities;
using System.Linq.Dynamic.Core;

namespace YMS.Migrations.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetCustomerByCode(string code, Guid branchId)
        {
            return await context.Customers.SingleOrDefaultAsync(u => u.Code == code && u.BranchId == branchId);
        }

        public async Task<IQueryable<Customer>> GetAllCustomersByBranchId(Guid? branchId, string? searchKey,string? SortField,int SortOrder)
        {
            var items = context.Customers.Where(e => !e.IsDeleted && (branchId == null ? true : e.BranchId == branchId)).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchKey))
                items = items.Where(e => e.NameEn.Contains(searchKey) || e.Code.Contains(searchKey));
            if (!string.IsNullOrWhiteSpace(SortField))
                items = items.OrderBy(string.Format("{0} {1}", SortField, SortOrder == 1 ? "ASC" : "DESC"));

            return items;
        }
    }
}
