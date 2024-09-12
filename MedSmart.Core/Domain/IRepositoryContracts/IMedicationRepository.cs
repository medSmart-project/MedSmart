using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedSmart.Core.Domain.IRepositoryContracts;

public interface IMedicationRepository
{
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
   // Task<IEnumerable<MedicationCardDto>> GetMedicationCards();
    Task<Medication> GetByIdAsync(int id);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}