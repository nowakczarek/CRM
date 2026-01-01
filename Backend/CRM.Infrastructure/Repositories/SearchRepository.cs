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
    public class SearchRepository : ISearchRepository
    {
        private readonly CrmDbContext context;

        public SearchRepository(CrmDbContext context)
        {
            this.context = context;
        }

        public async Task<GlobalSearchResults> GlobalSearch (string phrase, Guid userId)
        {
            if (string.IsNullOrEmpty(phrase))
                return new GlobalSearchResults();

            phrase = phrase.ToLower();

            var companies = await context.Companies
                .Where(c => c.UserId == userId)
                .Where(c => c.Name.ToLower().Contains(phrase) ||
                c.NIP.Contains(phrase) ||
                c.Industry.ToLower().Contains(phrase))
                .Take(15)
                .ToListAsync();

            var contacts = await context.Contacts
                .Where(c => c.UserId == userId)
                .Where(c => c.FirstName.ToLower().Contains(phrase) ||
                c.LastName.ToLower().Contains(phrase) ||
                c.Email.ToLower().Contains(phrase) ||
                c.PhoneNumber.Contains(phrase))
                .Take(15)
                .ToListAsync();

            var leads = await context.Leads
                .Where(c => c.UserId == userId)
                .Where(l => l.Title.ToLower().Contains(phrase))
                .Take(15)
                .ToListAsync();

            return new GlobalSearchResults
            {
                Companies = companies,
                Contacts = contacts,
                Leads = leads
            };
        }

        
    }
}
