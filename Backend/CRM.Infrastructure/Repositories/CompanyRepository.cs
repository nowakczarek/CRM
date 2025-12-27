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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(CrmDbContext context) : base(context)
        {

        }

        public async override Task<IEnumerable<Company>> GetAllAsync()
        {
            return await context.Companies
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }
    }
}
