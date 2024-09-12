using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IReminderService
{
    Task<Reminder> GetByIdAsync(int id);
    Task<IEnumerable<Reminder>> GetAllAsync();
    Task AddAsync(Reminder reminder);
    Task UpdateAsync(Reminder reminder);
    Task DeleteAsync(int id);

    // Methods related to scheduling and managing reminders
    Task ScheduleReminderAsync(Reminder reminder); // Schedule a reminder with Hangfire
    Task<IEnumerable<Reminder>> GetRemindersByUserIdAsync(int userId);
    Task DisableReminderAsync(int reminderId);
    Task ActivateReminderAsync(int reminderId);
    Task<bool> SendReminderNotificationAsync(Reminder reminder);

   
    Task SnoozeReminderAsync(int reminderId, TimeSpan snoozeTime); // Snooze a reminder for a specified duration
    Task<IEnumerable<Reminder>> GetUpcomingRemindersAsync(int userId, DateTime timeFrame); // Get reminders that are due soon
    Task RescheduleReminderAsync(int reminderId, DateTime newTime); // Reschedule a reminder
    Task<bool> IsReminderOverdueAsync(int reminderId); // Check if a reminder is overdue
    Task<IEnumerable<Reminder>> GetRemindersWithPriorityAsync(int priorityLevel); // Fetch reminders by priority
}