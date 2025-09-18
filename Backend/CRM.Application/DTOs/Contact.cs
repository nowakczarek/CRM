using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.DTOs
{
    public record ContactDto(
        Guid Id,
        Guid? CompanyId,
        string FirstName,
        string LastName,
        string? Email,
        string? PhoneNumber,
        string? Position,
        DateTime CreatedAt
        );

    public record CreateContactDto(
        Guid? CompanyId,
        string FirstName,
        string LastName,
        string? Email,
        string? PhoneNumber,
        string? Position
        );

    public record UpdateContactDto(
        Guid? CompanyId,
        string FirstName,
        string LastName,
        string? Email,
        string? PhoneNumber,
        string? Position
        );


}
