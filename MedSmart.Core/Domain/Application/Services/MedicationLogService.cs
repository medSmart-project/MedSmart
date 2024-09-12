using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class MedicationLogService : IMedicationLogService
{
    // Empty implementation
    public async Task<MedicationLog> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MedicationLog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(MedicationLog log)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(MedicationLog log)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MedicationLog>> GetByMedicationIdAsync(int medicationId)
    {
        throw new NotImplementedException();
    }
}