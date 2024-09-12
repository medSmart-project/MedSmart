using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IBrandService
{
    Task<Brand> GetByIdAsync(int id);
    Task<IEnumerable<Brand>> GetAllAsync();
    Task AddAsync(Brand brand);
    Task UpdateAsync(Brand brand);
    Task DeleteAsync(int id);
    Task<IEnumerable<Brand>> GetByNameAsync(string name);
}