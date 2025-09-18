using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Industry { get; set; }
        public string NIP { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
