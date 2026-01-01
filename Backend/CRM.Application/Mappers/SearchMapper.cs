using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.DTOs;
using CRM.Core.Models;

namespace CRM.Application.Mappers
{
    public static class SearchMapper
    {
        public static GlobalSearchDto ToGlobalSearchDto(this GlobalSearchResults search)
        {
            var companiesDto = search.Companies.Select(c => c.ToDto()).ToList();
            var contactsDto = search.Contacts.Select(c => c.ToDto()).ToList();
            var leadsDto = search.Leads.Select(c => c.ToDto()).ToList();

            return new GlobalSearchDto(
                companiesDto,
                contactsDto,
                leadsDto
                );
            
        }
    }
}
