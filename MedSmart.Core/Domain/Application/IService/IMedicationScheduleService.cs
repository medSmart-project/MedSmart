using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationScheduleService
{
    Task<MedicationSchedule> GetByIdAsync(int id);
    Task<IEnumerable<MedicationSchedule>> GetAllAsync();
    Task AddAsync(MedicationSchedule schedule);
    Task UpdateAsync(MedicationSchedule schedule);
    Task DeleteAsync(int id);
    Task<IEnumerable<MedicationSchedule>> GetByMedicationIdAsync(int medicationId);
}