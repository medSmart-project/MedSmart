using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface INotificationChannelService
{
    Task<NotificationChannel> GetByIdAsync(int id);
    Task<IEnumerable<NotificationChannel>> GetAllAsync();
    Task AddAsync(NotificationChannel channel);
    Task UpdateAsync(NotificationChannel channel);
    Task DeleteAsync(int id);

    
    Task<IEnumerable<NotificationChannel>> GetEnabledChannelsForUserAsync(int userId); // Fetch enabled channels for a user
    Task ToggleChannelAsync(int userId, string channelName, bool isEnabled); // Enable/disable a notification channel for a user
    Task SendNotificationViaChannelAsync(int userId, string channelName, string message, string title); // Send notification via a specific channel
}