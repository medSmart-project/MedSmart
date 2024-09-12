using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class OrderService : IOrderService
{
    // Empty implementation
    public async Task<Order> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}