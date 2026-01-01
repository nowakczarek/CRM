using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.DTOs
{
    public record GlobalSearchDto(
        IEnumerable<CompanyDto> Companies,
        IEnumerable<ContactDto> Contacts,
        IEnumerable<LeadDto> Leads 
        );
}
