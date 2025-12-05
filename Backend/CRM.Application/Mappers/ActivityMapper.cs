using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Models;
using CRM.Application.DTOs;

namespace CRM.Application.Mappers
{
    public static class ActivityMapper
    {
        public static ActivityDto ToDto(this Activity activity)
            => new ActivityDto(
                activity.Id,
                activity.CompanyId,
                activity.ContactId,
                activity.Type,
                activity.Subject,
                activity.Description,
                activity.CreatedAt
                );

        public static Activity ToEntity(this CreateActivityDto dto, Guid userId)
            => new Activity
            {
                Id = Guid.NewGuid(),
                CompanyId = dto.CompanyId,
                ContactId = dto.ContactId,
                UserId = userId,
                Type = dto.Type,
                Subject = dto.Subject,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

        public static void UpdateFrom(this Activity activity, UpdateActivityDto dto)
        {
            activity.Type = dto.Type;
            activity.Subject = dto.Subject;
            activity.Description = dto.Description;
        }

        public static FullActivityDto ToFullDto(this Activity activity)
            => new FullActivityDto(
                activity.Id,
                activity.CompanyId,
                activity.ContactId,
                activity.Type,
                activity.Company.Name,
                activity.Contact.FirstName,
                activity.Contact.LastName,
                activity.Subject,
                activity.Description,
                activity.CreatedAt
                );
    }
}
