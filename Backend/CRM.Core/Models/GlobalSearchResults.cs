using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Models
{
    public class GlobalSearchResults
    {
        public IEnumerable<Company> Companies { get; set; } = new List<Company>();
        public IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();
        public IEnumerable<Lead> Leads { get; set; } = new List<Lead>();
    }
}
