using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
    }
}
