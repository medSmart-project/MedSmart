using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class FailedReminderLogService : IFailedReminderLogService
{
    // Empty implementation
    public async Task<FailedReminderLog> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FailedReminderLog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(FailedReminderLog failedLog)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FailedReminderLog>> GetFailedRemindersByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task RetryFailedReminderAsync(int reminderId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalFailedRemindersAsync()
    {
        throw new NotImplementedException();
    }
}