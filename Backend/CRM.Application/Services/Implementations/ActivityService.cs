using CRM.Application.Services.Interfaces;
using CRM.Core.Interfaces.Repositories;
using CRM.Core.Models;

namespace CRM.Application.Services.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity> repository;

        public ActivityService(IRepository<Activity> repository)
        {
            this.repository = repository;
        }
        public async Task<Activity> AddAsync(Activity activity, Guid userId)
        {
            if (activity.UserId != userId)
            {
                return null;
            }

            await repository.AddAsync(activity);
            return activity;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userId)
        {
            var existingActivity = await repository.GetByIdAsync(id);

            if (existingActivity is null || existingActivity.UserId != userId)
            {
                return false;
            }

            await repository.DeleteAsync(existingActivity);
            return true;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync(Guid userId)
        {
            var all = await repository.GetAllAsync();
            return all.Where(x => x.UserId == userId);
        }

        public async Task<Activity?> GetByIdAsync(Guid id, Guid userId)
        {
            var activity = await repository.GetByIdAsync(id);

            if (activity?.UserId == userId)
            {
                return activity;
            }
            return null;
        }

        public async Task<Activity?> UpdateAsync(Activity activity, Guid userId)
        {
            var existingActivity = await repository.GetByIdAsync(activity.Id);

            if (existingActivity is null || existingActivity.UserId != userId)
            {
                return null;
            }

            existingActivity.Subject = activity.Subject;
            existingActivity.Description = activity.Description;
            existingActivity.Type = activity.Type;

            await repository.UpdateAsync(activity);
            return existingActivity;

        }
    }
}
