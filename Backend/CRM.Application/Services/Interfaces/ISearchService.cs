using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;

namespace CRM.Application.Services.Interfaces
{
    public interface ISearchService
    {
        Task<GlobalSearchResults> GlobalSearch(string phrase, Guid userId);
    }
}
