using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;

namespace CRM.Core.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        Task<GlobalSearchResults> GlobalSearch(string phrase, Guid userId);
    }
}
