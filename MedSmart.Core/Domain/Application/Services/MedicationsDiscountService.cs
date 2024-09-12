using System.Linq.Expressions;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class MedicationsDiscountService : IMedicationsDiscountService
{
    // Empty implementation
    public async Task<IEnumerable<MedicationsDiscountDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<MedicationsDiscountDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(MedicationsDiscountDto discountDto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, MedicationsDiscountDto discountDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MedicationsDiscountDto>> FindAsync(Expression<Func<MedicationsDiscount, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}