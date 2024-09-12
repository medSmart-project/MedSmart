using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class HangfireJobService : IHangfireJobService
{
    // Empty implementation
    public async Task<HangfireJob> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<HangfireJob>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(HangfireJob job)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(HangfireJob job)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<HangfireJob>> GetByStatusAsync(string status)
    {
        throw new NotImplementedException();
    }
}