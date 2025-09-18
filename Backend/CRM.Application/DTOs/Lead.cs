using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Enums;

namespace CRM.Application.DTOs
{
    public record LeadDto(
        Guid Id,
        Guid CompanyId,
        Guid ContactId,
        string Title,
        decimal Value,
        LeadStage Stage,
        DateTime CreatedAt
        );

    public record CreateLeadDto(
        Guid CompanyId,
        Guid ContactId,
        string Title,
        decimal Value,
        LeadStage Stage
        );

    public record UpdateLeadDto(
        Guid CompanyId,
        Guid ContactId,
        string Title,
        decimal Value,
        LeadStage Stage
        );
}
