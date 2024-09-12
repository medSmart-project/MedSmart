using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface INotificationLogService
{
    Task<NotificationLog> GetByIdAsync(int id);
    Task<IEnumerable<NotificationLog>> GetAllAsync();
    Task AddAsync(NotificationLog log);
    Task UpdateAsync(NotificationLog log);
    Task DeleteAsync(int id);

    // Methods related to notifications
    Task SendNotificationAsync(int userId, string message, string title);
    Task<IEnumerable<NotificationLog>> GetByUserIdAsync(int userId);
    Task<IEnumerable<NotificationLog>> GetPendingNotificationsAsync();

    // Additional notification management
    Task RetryFailedNotificationsAsync(); // Retry sending failed notifications
    Task<int> GetUserNotificationCountAsync(int userId); // Get total notification count for a user
    Task MarkNotificationsAsReadAsync(int userId); // Mark all notifications as read for a user
}