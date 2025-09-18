using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Position { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
        public Company? Company { get; set; }
    }
}
