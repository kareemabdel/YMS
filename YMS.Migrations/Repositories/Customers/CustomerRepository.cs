using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Data;

namespace YMS.Migrations.Repositories.Customers
{
    public class CustomerRepository : Repository<Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
