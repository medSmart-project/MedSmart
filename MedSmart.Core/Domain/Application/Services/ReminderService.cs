using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class ReminderService : IReminderService
{
    // Empty implementation
    public async Task<Reminder> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Reminder>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task ScheduleReminderAsync(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Reminder>> GetRemindersByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task DisableReminderAsync(int reminderId)
    {
        throw new NotImplementedException();
    }

    public async Task ActivateReminderAsync(int reminderId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SendReminderNotificationAsync(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public async Task SnoozeReminderAsync(int reminderId, TimeSpan snoozeTime)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Reminder>> GetUpcomingRemindersAsync(int userId, DateTime timeFrame)
    {
        throw new NotImplementedException();
    }

    public async Task RescheduleReminderAsync(int reminderId, DateTime newTime)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsReminderOverdueAsync(int reminderId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Reminder>> GetRemindersWithPriorityAsync(int priorityLevel)
    {
        throw new NotImplementedException();
    }
}