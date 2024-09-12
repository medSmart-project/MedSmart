using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class OrderDetailService : IOrderDetailService
{
    // Empty implementation
    public async Task<OrderDetail> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderDetail>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(OrderDetail orderDetail)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(OrderDetail orderDetail)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }
}