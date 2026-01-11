using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;

namespace CRM.Core.Interfaces.Repositories
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task<IEnumerable<Lead>> GetByCompanyId(Guid companyId);
        Task<IEnumerable<Lead>> GetByContactId(Guid contactId);
    }
}
