using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IPrescriptionService
{
    Task<Prescription> GetByIdAsync(int id);
    Task<IEnumerable<Prescription>> GetAllAsync();
    Task AddAsync(Prescription prescription);
    Task UpdateAsync(Prescription prescription);
    Task DeleteAsync(int id);
    Task<IEnumerable<Prescription>> GetByUserIdAsync(int userId);
}