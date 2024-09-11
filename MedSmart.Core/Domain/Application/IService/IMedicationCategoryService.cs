using System.Linq.Expressions;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationCategoryService
{
    Task AddCategory(MedicationCategoryDto categoryDto);
    Task<bool> UpdateAsync(MedicationCategoryDto categoryDto);
    Task<bool> DeleteAsync(int id);
    Task<MedicationCategoryDto?> GetByIdAsync(int id);
    Task<IEnumerable<MedicationCategoryDto>> GetAllAsync();
    Task<IEnumerable<MedicationCategoryDto>> FindAsync(Expression<Func<MedicationCategory, bool>> predicate);
    Task<MedicationCategory?> DetermineCategoryAsync(string categoryName);
}