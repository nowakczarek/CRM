using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Enums;

namespace CRM.Application.DTOs
{
    public record ActivityDto(
        Guid Id,
        Guid CompanyId,
        Guid ContactId,
        ActivityType Type,
        string Subject,
        string? Description,
        DateTime CreatedAt
        );

    public record CreateActivityDto(
        Guid CompanyId,
        Guid ContactId,
        ActivityType Type,
        string Subject,
        string? Description
        );

    public record UpdateActivityDto(
        ActivityType Type,
        string Subject,
        string? Description
        );
    
}
