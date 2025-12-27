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
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(CrmDbContext context) : base(context)
        {
            
        }

        public override async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await context.Activities
                .Include(c => c.Company)
                .Include(c => c.Contact)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllByContactId(Guid contactId)
        {
            return await context.Activities
                .Include(c => c.Company)
                .Include(c => c.Contact)
                .Where(a => a.ContactId == contactId).ToListAsync();
        }

        public async override Task<Activity> GetByIdAsync(Guid id)
        {
            return await context.Activities
                .Include(c => c.Company)
                .FirstAsync(a => a.Id == id);
        }
    }
}
