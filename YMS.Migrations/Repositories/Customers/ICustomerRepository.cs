using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Migrations.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Entities.Customer>
    {
        Task<IQueryable<Customer>> GetAllCustomersByBranchId(Guid? branchId, string? searchKey, string? SortField, int SortOrder);
        Task<Customer> GetCustomerByCode(string code, Guid branchId);
    }
}
