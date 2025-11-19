using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Interfaces.Repositories;
using CRM.Core.Models;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(CrmDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Contact>> GetByCompanyIdAsync(Guid companyId)
        {
            return await context.Contacts.Where(c => c.CompanyId == companyId).ToListAsync();
        }
    }
}
