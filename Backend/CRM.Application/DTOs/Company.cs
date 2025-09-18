using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.DTOs
{
    public record CompanyDto(
        Guid Id,
        string Name,
        string? Industry,
        string NIP,
        string? Website,
        string? PhoneNumber,
        string? Address,
        DateTime CreatedAt
        );

    public record CreateCompanyDto(
        string Name,
        string? Industry,
        string NIP,
        string? Website,
        string? PhoneNumber,
        string? Address
        );

    public record UpdateCompanyDto(
        Guid Id,
        string Name,
        string? Industry,
        string NIP,
        string? Website,
        string? PhoneNumber,
        string? Address
        );

}
