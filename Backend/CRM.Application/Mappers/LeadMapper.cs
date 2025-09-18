using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.DTOs;
using CRM.Core.Models;

namespace CRM.Application.Mappers
{
    public static class LeadMapper
    {
        public static LeadDto ToDto(this Lead lead)
            => new LeadDto(
                lead.Id,
                lead.CompanyId,
                lead.ContactId,
                lead.Title,
                lead.Value,
                lead.Stage,
                lead.CreatedAt
                );

        public static Lead ToEntity(this CreateLeadDto dto, Guid userId)
            => new Lead
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CompanyId = dto.CompanyId,
                ContactId = dto.ContactId,
                Title = dto.Title,
                Value = dto.Value,
                Stage = dto.Stage,
                CreatedAt = DateTime.UtcNow,
            };

        public static void UpdateFrom(this Lead lead, UpdateLeadDto dto)
        {
            lead.CompanyId = dto.CompanyId;
            lead.ContactId = dto.ContactId;
            lead.Title = dto.Title;
            lead.Value = dto.Value;
            lead.Stage = dto.Stage;
        }
    }
}
