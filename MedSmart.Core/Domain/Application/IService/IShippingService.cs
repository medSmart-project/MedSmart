using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IShippingService
{
    Task<Shipping> GetByIdAsync(int id);
    Task<IEnumerable<Shipping>> GetAllAsync();
    Task AddAsync(Shipping shipping);
    Task UpdateAsync(Shipping shipping);
    Task DeleteAsync(int id);
    Task<IEnumerable<Shipping>> GetByOrderIdAsync(int orderId);
}