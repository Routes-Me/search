using SearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchService.Abstraction
{
    public interface ISearchRepository
    {
        dynamic GetVehicles(string query, string context, Pagination pageInfo);
    }
}
