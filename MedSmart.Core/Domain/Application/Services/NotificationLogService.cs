using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class NotificationLogService : INotificationLogService
{
    // Empty implementation
    public async Task<NotificationLog> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<NotificationLog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(NotificationLog log)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(NotificationLog log)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task SendNotificationAsync(int userId, string message, string title)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<NotificationLog>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<NotificationLog>> GetPendingNotificationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task RetryFailedNotificationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetUserNotificationCountAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task MarkNotificationsAsReadAsync(int userId)
    {
        throw new NotImplementedException();
    }
}