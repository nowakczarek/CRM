using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Enums;

namespace CRM.Core.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }

        public ActivityType Type { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Company Company { get; set; }
        public Contact Contact { get; set; }
    }
}
