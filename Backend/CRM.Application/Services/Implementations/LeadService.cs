using CRM.Application.Services.Interfaces;
using CRM.Core.Interfaces.Repositories;
using CRM.Core.Models;

namespace CRM.Application.Services.Implementations
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository repository;

        public LeadService(ILeadRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Lead> AddAsync(Lead lead, Guid userId)
        {
            if (lead.UserId != userId)
            {
                return null;
            }

            await repository.AddAsync(lead);
            return lead;
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

        public async Task<IEnumerable<Lead>> GetAllAsync(Guid userId)
        {
            var all = await repository.GetAllAsync();
            return all.Where(l => l.UserId == userId);
        }

        public async Task<Lead?> GetByIdAsync(Guid id, Guid userId)
        {
            var lead = await repository.GetByIdAsync(id);

            if (lead?.UserId == userId)
            {
                return lead;
            }

            return null;
        }

        public async Task<Lead?> UpdateAsync(Lead lead, Guid userId)
        {
            var existing = await repository.GetByIdAsync(lead.Id);

            if (existing is null || existing.UserId != userId)
            {
                return null;
            }

            existing.Title = lead.Title;
            existing.Value = lead.Value;
            existing.Stage = lead.Stage;

            await repository.UpdateAsync(existing);
            return existing;
        }
    }
}
