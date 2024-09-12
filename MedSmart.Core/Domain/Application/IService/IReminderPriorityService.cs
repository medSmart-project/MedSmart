using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IReminderPriorityService
{
    Task<ReminderPriority> GetByIdAsync(int id);
    Task<IEnumerable<ReminderPriority>> GetAllAsync();
    Task AddAsync(ReminderPriority priority);
    Task UpdateAsync(ReminderPriority priority);
    Task DeleteAsync(int id);

    
    Task<IEnumerable<ReminderPriority>> GetPrioritiesByLevelAsync(int level); // Get priorities by specific level
    Task SetDefaultPriorityAsync(int userId, int priorityLevel); // Set a default priority for a user's reminders
}