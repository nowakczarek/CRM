using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.DTOs;
using CRM.Core.Models;

namespace CRM.Application.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company?> GetByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<Company>> GetAllAsync(Guid userId);
        Task<Company> AddAsync(Company entity, Guid userId);
        Task<Company?> UpdateAsync(Company entity, Guid userId);
        Task<bool> DeleteAsync(Guid id, Guid userId);
    }
}
