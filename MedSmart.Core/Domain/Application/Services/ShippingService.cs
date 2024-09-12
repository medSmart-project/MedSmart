using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class ShippingService : IShippingService
{
    // Empty implementation
    public async Task<Shipping> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Shipping>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Shipping shipping)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Shipping shipping)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Shipping>> GetByOrderIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }
}