using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Entities.Customer>
    {
        Task<IQueryable<Entities.Customer>> GetAllCustomersByBranchId(Guid? branchId,string? searchKey);
    }
}
