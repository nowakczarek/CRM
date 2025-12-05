using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;

namespace CRM.Application.Services.Interfaces
{
    public interface IActivityService
    {
        Task<Activity?> GetByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<Activity>> GetAllAsync(Guid userId);
        Task<IEnumerable<Activity>> GetAllByContactId(Guid contactId, Guid userId);
        Task<Activity> AddAsync(Activity entity, Guid userId);
        Task<Activity?> UpdateAsync(Activity entity, Guid userId);
        Task<bool> DeleteAsync(Guid id, Guid userId);
    }
}
