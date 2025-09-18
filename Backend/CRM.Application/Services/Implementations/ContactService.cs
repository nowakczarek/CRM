using CRM.Application.Services.Interfaces;
using CRM.Core.Interfaces.Repositories;
using CRM.Core.Models;

namespace CRM.Application.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> repository;

        public ContactService(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task<Contact> AddAsync(Contact contact, Guid userId)
        {
            if (contact.UserId != userId)
            {
                return null;
            }

            await repository.AddAsync(contact);
            return contact;
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

        public async Task<IEnumerable<Contact>> GetAllAsync(Guid userId)
        {
            var all = await repository.GetAllAsync();
            return all.Where(c => c.UserId == userId);
        }

        public async Task<Contact?> GetByIdAsync(Guid id, Guid userId)
        {
            var lead = await repository.GetByIdAsync(id);

            if (lead?.UserId == userId)
            {
                return lead;
            }

            return null;
        }

        public async Task<Contact?> UpdateAsync(Contact contact, Guid userId)
        {
            var existing = await repository.GetByIdAsync(contact.Id);

            if (existing is null || existing.UserId != userId)
            {
                return null;
            }

            existing.FirstName= contact.FirstName;
            existing.LastName= contact.LastName;
            existing.Email= contact.Email;
            existing.PhoneNumber= contact.PhoneNumber;
            existing.Position= contact.Position;
            existing.CompanyId = contact.CompanyId;

            await repository.UpdateAsync(existing);
            return existing;
        }
    }
}
