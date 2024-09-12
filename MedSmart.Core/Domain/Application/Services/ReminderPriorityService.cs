using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class ReminderPriorityService : IReminderPriorityService
{
    // Empty implementation
    public async Task<ReminderPriority> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderPriority>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ReminderPriority priority)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ReminderPriority priority)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderPriority>> GetPrioritiesByLevelAsync(int level)
    {
        throw new NotImplementedException();
    }

    public async Task SetDefaultPriorityAsync(int userId, int priorityLevel)
    {
        throw new NotImplementedException();
    }
}