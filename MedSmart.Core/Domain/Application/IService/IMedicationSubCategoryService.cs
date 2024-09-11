using System.Linq.Expressions;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationSubCategoryService
{
    Task AddSubCategory(MedicationSubCategoryDto subCategoryDto);
    Task<bool> UpdateAsync(MedicationSubCategoryDto subCategoryDto);
    Task<bool> DeleteAsync(int id);
    Task<MedicationSubCategoryDto?> GetByIdAsync(int id);
    Task<IEnumerable<MedicationSubCategoryDto>> GetAllAsync();
    Task<IEnumerable<MedicationSubCategoryDto>> FindAsync(Expression<Func<MedicationSubCategory, bool>> predicate);
    Task<MedicationSubCategory?> DetermineSubCategoryAsync(string subCategoryName);
}