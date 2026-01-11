using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;

namespace CRM.Application.Services.Interfaces
{
    public interface ILeadService
    {
        Task<Lead?> GetByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<Lead>> GetAllAsync(Guid userId);
        Task<IEnumerable<Lead>> GetByCompanyId(Guid userId, Guid companyId);
        Task<IEnumerable<Lead>> GetByContactId(Guid userId, Guid contactId);
        Task<Lead> AddAsync(Lead entity, Guid userId);
        Task<Lead?> UpdateAsync(Lead entity, Guid userId);
        Task<bool> DeleteAsync(Guid id, Guid userId);
    }
}
