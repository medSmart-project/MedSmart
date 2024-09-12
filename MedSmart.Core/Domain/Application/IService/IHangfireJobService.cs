using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IHangfireJobService
{
    Task<HangfireJob> GetByIdAsync(int id);
    Task<IEnumerable<HangfireJob>> GetAllAsync();
    Task AddAsync(HangfireJob job);
    Task UpdateAsync(HangfireJob job);
    Task DeleteAsync(int id);
    Task<IEnumerable<HangfireJob>> GetByStatusAsync(string status);
}