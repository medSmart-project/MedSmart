using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationGetService
{
    Task AddAsync(Medication medication);
    Task UpdateAsync(Medication medication);
    Task DeleteAsync(int medicationId);
    Task<Medication> GetByIdAsync(int medicationId);
    Task<IEnumerable<Medication>> GetAllAsync();
    Task<IEnumerable<Medication>> GetMedicationsByFilterAsync(MedicationFilter filter);
    Task<IEnumerable<Medication>> SearchMedicationsAsync(string searchTerm);
    Task<IEnumerable<Medication>> GetTopSellingMedicationsAsync();
    Task<IEnumerable<Medication>> GetNewestMedicationsAsync();
    Task<IEnumerable<Medication>> GetFeaturedMedicationsAsync();
    Task<IEnumerable<Medication>> GetMedicationsOnSaleAsync();
    Task<IEnumerable<Medication>> GetMedicationsBySupplierAsync(int supplierId);
    Task<IEnumerable<Medication>> GetOutOfStockMedicationsAsync();
    Task<IEnumerable<Medication>> GetRecommendedMedicationsAsync();
    Task<IEnumerable<Medication>> GetSimilarOrRelatedMedicationsAsync(int medicationId, bool related = false);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}