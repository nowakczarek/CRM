using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.DTOs;
using CRM.Core.Models;

namespace CRM.Application.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyDto ToDto(this Company company)
            => new CompanyDto(
                company.Id,
                company.Name,
                company.Industry,
                company.NIP,
                company.Website,
                company.PhoneNumber,
                company.Address,
                company.CreatedAt
                );

        public static Company ToEntity(this CreateCompanyDto dto, Guid userId)
            => new Company
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Industry = dto.Industry,
                NIP = dto.NIP,
                Website = dto.Website,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

        public static void UpdateFrom(this Company company, UpdateCompanyDto dto)
        {
            company.Name = dto.Name;
            company.Industry = dto.Industry;
            company.NIP = dto.NIP;
            company.Website = dto.Website;
            company.PhoneNumber = dto.PhoneNumber;
            company.Address = dto.Address;
        }
    }
}
