using System.Linq.Expressions;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationsDiscountService
{
    Task<IEnumerable<MedicationsDiscountDto>> GetAllAsync();
    Task<MedicationsDiscountDto?> GetByIdAsync(int id);
    Task AddAsync(MedicationsDiscountDto discountDto);
    Task UpdateAsync(int id, MedicationsDiscountDto discountDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<MedicationsDiscountDto>> FindAsync(Expression<Func<MedicationsDiscount, bool>> predicate);
}