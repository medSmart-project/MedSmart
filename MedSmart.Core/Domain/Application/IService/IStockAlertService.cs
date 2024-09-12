using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IStockAlertService
{
    Task<StockAlert> GetByIdAsync(int id);
    Task<IEnumerable<StockAlert>> GetAllAsync();
    Task AddAsync(StockAlert alert);
    Task UpdateAsync(StockAlert alert);
    Task DeleteAsync(int id);
    Task<IEnumerable<StockAlert>> GetByMedicationIdAsync(int medicationId);
}