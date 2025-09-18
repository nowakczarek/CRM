using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;
using CRM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Data
{
    public class CrmDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public CrmDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CrmDbContext).Assembly);
        }

    }
}
