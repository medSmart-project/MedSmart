using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IFailedReminderLogService
{
    Task<FailedReminderLog> GetByIdAsync(int id);
    Task<IEnumerable<FailedReminderLog>> GetAllAsync();
    Task AddAsync(FailedReminderLog failedLog);
    Task DeleteAsync(int id);

    
    Task<IEnumerable<FailedReminderLog>> GetFailedRemindersByUserIdAsync(int userId); // Fetch failed reminders by user
    Task RetryFailedReminderAsync(int reminderId); // Retry sending a failed reminder
    Task<int> GetTotalFailedRemindersAsync(); // Get total count of failed reminders
}