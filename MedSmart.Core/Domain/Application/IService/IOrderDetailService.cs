using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IOrderDetailService
{
    Task<OrderDetail> GetByIdAsync(int id);
    Task<IEnumerable<OrderDetail>> GetAllAsync();
    Task AddAsync(OrderDetail orderDetail);
    Task UpdateAsync(OrderDetail orderDetail);
    Task DeleteAsync(int id);
    Task<IEnumerable<OrderDetail>> GetByOrderIdAsync(int orderId);
}