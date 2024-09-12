using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class SupplierService : ISupplierService
{
    // Empty implementation
    public async Task<Supplier> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Supplier supplier)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Supplier>> GetByBrandIdAsync(int brandId)
    {
        throw new NotImplementedException();
    }
}