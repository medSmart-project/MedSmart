using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class NotificationChannelService : INotificationChannelService
{
    // Empty implementation
    public async Task<NotificationChannel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<NotificationChannel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(NotificationChannel channel)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(NotificationChannel channel)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<NotificationChannel>> GetEnabledChannelsForUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task ToggleChannelAsync(int userId, string channelName, bool isEnabled)
    {
        throw new NotImplementedException();
    }

    public async Task SendNotificationViaChannelAsync(int userId, string channelName, string message, string title)
    {
        throw new NotImplementedException();
    }
}