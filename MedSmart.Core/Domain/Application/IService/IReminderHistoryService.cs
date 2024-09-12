using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IReminderHistoryService
{
    Task<ReminderHistory> GetByIdAsync(int id);
    Task<IEnumerable<ReminderHistory>> GetAllAsync();
    Task AddAsync(ReminderHistory history);
    Task UpdateAsync(ReminderHistory history);
    Task DeleteAsync(int id);

    // Additional methods
    Task<IEnumerable<ReminderHistory>> GetByReminderIdAsync(int reminderId);
    Task<IEnumerable<ReminderHistory>> GetByUserIdAsync(int userId);

    // Methods to analyze reminder history
    Task<int> GetReminderCompletionRateAsync(int userId); // Calculate the rate of reminders completed by the user
    Task<IEnumerable<ReminderHistory>> GetFailedRemindersAsync(); // Get reminders that failed to execute
    Task LogReminderAttemptAsync(int reminderId, bool success); // Log an attempt to send a reminder, successful or not
}