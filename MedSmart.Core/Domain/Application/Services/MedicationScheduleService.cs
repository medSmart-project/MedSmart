using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class MedicationScheduleService : IMedicationScheduleService
{
    // Empty implementation
    public async Task<MedicationSchedule> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MedicationSchedule>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(MedicationSchedule schedule)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(MedicationSchedule schedule)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MedicationSchedule>> GetByMedicationIdAsync(int medicationId)
    {
        throw new NotImplementedException();
    }
}