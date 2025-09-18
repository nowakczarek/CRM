using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;

namespace CRM.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<Contact?> GetByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<Contact>> GetAllAsync(Guid userId);
        Task<Contact> AddAsync(Contact entity, Guid userId);
        Task<Contact?> UpdateAsync(Contact entity, Guid userId);
        Task<bool> DeleteAsync(Guid id, Guid userId);
    }
}
