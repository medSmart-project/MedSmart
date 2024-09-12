using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class ReminderHistoryService : IReminderHistoryService
{
    // Empty implementation
    public async Task<ReminderHistory> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderHistory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ReminderHistory history)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ReminderHistory history)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderHistory>> GetByReminderIdAsync(int reminderId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderHistory>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetReminderCompletionRateAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReminderHistory>> GetFailedRemindersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task LogReminderAttemptAsync(int reminderId, bool success)
    {
        throw new NotImplementedException();
    }
}