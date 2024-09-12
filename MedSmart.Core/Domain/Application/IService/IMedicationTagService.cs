using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationTagService
{
    Task<MedicationTag> GetByIdAsync(int id);
    Task<IEnumerable<MedicationTag>> GetAllAsync();
    Task AddAsync(MedicationTag tag);
    Task UpdateAsync(MedicationTag tag);
    Task DeleteAsync(int id);
    Task<IEnumerable<MedicationTag>> GetByMedicationIdAsync(int medicationId);
}