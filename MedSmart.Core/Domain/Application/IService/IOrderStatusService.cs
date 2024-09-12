using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IOrderStatusService
{
    Task<OrderStatus> GetByIdAsync(int id);
    Task<IEnumerable<OrderStatus>> GetAllAsync();
    Task AddAsync(OrderStatus status);
    Task UpdateAsync(OrderStatus status);
    Task DeleteAsync(int id);
    Task<IEnumerable<OrderStatus>> GetByOrderIdAsync(int orderId);
}