using CRM.Application.DTOs;
using CRM.Application.Services.Interfaces;
using CRM.Core.Interfaces.Repositories;
using CRM.Core.Models;

namespace CRM.Application.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;

        public CompanyService(IRepository<Company> repository)
        {
            this.repository = repository;
        }

        public async Task<Company> AddAsync(Company company, Guid userId)
        {
            if (company.UserId != userId)
            {
                return null;
            }

            await repository.AddAsync(company);
            return company;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userId)
        {
            var existing = await repository.GetByIdAsync(id);

            if (existing is null || existing.UserId != userId)
            {
                return false;
            }

            await repository.DeleteAsync(existing);
            return true;
        }

        public async Task<IEnumerable<Company>> GetAllAsync(Guid userId)
        {
            var all = await repository.GetAllAsync();
            return all.Where(x => x.UserId == userId);
        }

        public async Task<Company?> GetByIdAsync(Guid id, Guid userId)
        {
            var company = await repository.GetByIdAsync(id);

            if (company?.UserId == userId)
            {
                return company;
            }
            return null;
        }

        public async Task<Company?> UpdateAsync(Company company, Guid userId)
        {
            var existing = await repository.GetByIdAsync(company.Id);

            if (existing is null || existing.UserId != userId)
            {
                return null;
            }

            existing.Name = company.Name;
            existing.Industry = company.Industry;
            existing.NIP = company.NIP;
            existing.Website = company.Website;
            existing.PhoneNumber = company.PhoneNumber;
            existing.Address = company.Address;

            await repository.UpdateAsync(company);
            return company;
        }
    }
}
