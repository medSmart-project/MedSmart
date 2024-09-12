using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class DoctorService : IDoctorService
{
    // Empty implementation
    public async Task<Doctor> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization)
    {
        throw new NotImplementedException();
    }
}