using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class BrandService : IBrandService
{
    // Empty implementation
    public async Task<Brand> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Brand brand)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Brand brand)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Brand>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}