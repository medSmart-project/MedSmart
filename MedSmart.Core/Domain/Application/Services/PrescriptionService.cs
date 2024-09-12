using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class PrescriptionService : IPrescriptionService
{
    // Empty implementation
    public async Task<Prescription> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Prescription>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Prescription>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}