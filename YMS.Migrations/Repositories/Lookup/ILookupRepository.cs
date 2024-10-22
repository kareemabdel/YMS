using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Repositories.Customers
{
    public interface ILookupRepository  // for  example 
    {
       List<Country> GetContries();
       List<City> GetCities(int countryId);
       List<Line> GetLines();
       List<Currency> GetCurrencies();
       List<Service> GetServices();
       List<Basis> GetBasises();
       List<ContainerType> GetContainerTypes();
    }
}
