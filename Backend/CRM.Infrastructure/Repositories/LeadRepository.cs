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
    public class LeadRepository : Repository<Lead>, ILeadRepository
    {
        public LeadRepository(CrmDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await context.Leads
                .Include(c => c.Company)
                .Include(c => c.Contact)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetByCompanyId(Guid companyId)
        {
            return await context.Leads.Where(l => l.CompanyId == companyId).ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetByContactId(Guid contactId)
        {
            return await context.Leads.Where(l => l.ContactId == contactId).ToListAsync();
        }
    }
}
