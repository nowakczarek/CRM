using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.DTOs;
using CRM.Core.Models;

namespace CRM.Application.Mappers
{
    public static class ContactMapper
    {
        public static ContactDto ToDto(this Contact contact)
            => new ContactDto(
                contact.Id,
                contact.CompanyId,
                contact.FirstName,
                contact.LastName,
                contact.Email,
                contact.PhoneNumber,
                contact.Position,
                contact.CreatedAt
                );

        public static Contact ToEntity(this CreateContactDto dto, Guid userId)
            => new Contact
            {
                Id = Guid.NewGuid(),
                CompanyId = dto.CompanyId,
                UserId = userId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Position = dto.Position,
                CreatedAt = DateTime.UtcNow
            };

        public static void UpdateFrom(this Contact contact, UpdateContactDto dto)
        {
            contact.CompanyId = dto.CompanyId;
            contact.FirstName = dto.FirstName;
            contact.LastName = dto.LastName;
            contact.Email = dto.Email;
            contact.PhoneNumber = dto.PhoneNumber;
            contact.Position = dto.Position;
        }

        public static ContactWithCompanyDto ToDtoWithCompany(this Contact contact)
            => new ContactWithCompanyDto(
                contact.Id,
                contact.CompanyId,
                contact.Company.Name,
                contact.FirstName,
                contact.LastName,
                contact.Email,
                contact.PhoneNumber,
                contact.Position,
                contact.CreatedAt
                );
    }
}
