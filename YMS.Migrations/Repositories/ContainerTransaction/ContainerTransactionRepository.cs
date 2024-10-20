using Microsoft.EntityFrameworkCore;
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
    public class ContainerTransactionRepository : Repository<ContainerTransaction>, IContainerTransactionRepository
    {
        public ContainerTransactionRepository(AppDbContext context) : base(context)
        {
        }

    }
}
