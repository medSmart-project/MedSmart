using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class OrderStatusService : IOrderStatusService
{
    // Empty implementation
    public async Task<OrderStatus> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderStatus>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(OrderStatus status)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(OrderStatus status)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderStatus>> GetByOrderIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }
}