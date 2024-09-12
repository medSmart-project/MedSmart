using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task<User> GetByEmailAsync(string email);
}