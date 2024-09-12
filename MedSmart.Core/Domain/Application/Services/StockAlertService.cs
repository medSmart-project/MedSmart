using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class StockAlertService : IStockAlertService
{
    // Empty implementation
    public async Task<StockAlert> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<StockAlert>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(StockAlert alert)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(StockAlert alert)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<StockAlert>> GetByMedicationIdAsync(int medicationId)
    {
        throw new NotImplementedException();
    }
}