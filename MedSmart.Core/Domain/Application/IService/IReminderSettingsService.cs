using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IReminderSettingsService
{
    Task<ReminderSettings> GetByIdAsync(int id);
    Task<IEnumerable<ReminderSettings>> GetAllAsync();
    Task AddAsync(ReminderSettings settings);
    Task UpdateAsync(ReminderSettings settings);
    Task DeleteAsync(int id);

    // Methods for advanced settings
    Task<IEnumerable<ReminderSettings>> GetByUserIdAsync(int userId);
    Task UpdateUserReminderSettingsAsync(int userId, ReminderSettings settings);
    Task<ReminderSettings> GetUserPreferredSettingsAsync(int userId);

    
    Task ToggleNotificationChannelAsync(int userId, string channel, bool isEnabled); // Enable/disable specific notification channels (e.g., email, SMS, push notifications)
    Task SetReminderFrequencyAsync(int userId, string frequency); // Set default reminder frequency (daily, weekly, etc.)
    Task SetReminderPriorityDefaultAsync(int userId, int priorityLevel); // Set default priority level for reminders
}