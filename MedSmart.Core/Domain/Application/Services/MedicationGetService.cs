using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedSmart.Core.Domain.Application.Services;

public class MedicationGetService : IMedicationGetService
{
    // Empty implementation
    public async Task AddAsync(Medication medication)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Medication medication)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int medicationId)
    {
        throw new NotImplementedException();
    }

    public async Task<Medication> GetByIdAsync(int medicationId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetMedicationsByFilterAsync(MedicationFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> SearchMedicationsAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetTopSellingMedicationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetNewestMedicationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetFeaturedMedicationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetMedicationsOnSaleAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetMedicationsBySupplierAsync(int supplierId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetOutOfStockMedicationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetRecommendedMedicationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Medication>> GetSimilarOrRelatedMedicationsAsync(int medicationId, bool related = false)
    {
        throw new NotImplementedException();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public async Task RollbackTransactionAsync()
    {
        throw new NotImplementedException();
    }
}