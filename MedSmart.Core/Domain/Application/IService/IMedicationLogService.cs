using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationLogService
{
    Task<MedicationLog> GetByIdAsync(int id);
    Task<IEnumerable<MedicationLog>> GetAllAsync();
    Task AddAsync(MedicationLog log);
    Task UpdateAsync(MedicationLog log);
    Task DeleteAsync(int id);
    Task<IEnumerable<MedicationLog>> GetByMedicationIdAsync(int medicationId);
}