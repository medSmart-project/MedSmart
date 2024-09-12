using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class ReminderSettingsService : IReminderSettingsService
{
    // Empty implementation
    public async Task<ReminderSettings> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderSettings>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ReminderSettings settings)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ReminderSettings settings)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderSettings>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserReminderSettingsAsync(int userId, ReminderSettings settings)
    {
        throw new NotImplementedException();
    }

    public async Task<ReminderSettings> GetUserPreferredSettingsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task ToggleNotificationChannelAsync(int userId, string channel, bool isEnabled)
    {
        throw new NotImplementedException();
    }

    public async Task SetReminderFrequencyAsync(int userId, string frequency)
    {
        throw new NotImplementedException();
    }

    public async Task SetReminderPriorityDefaultAsync(int userId, int priorityLevel)
    {
        throw new NotImplementedException();
    }
}