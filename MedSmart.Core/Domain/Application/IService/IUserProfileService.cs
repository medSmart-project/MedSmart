using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IUserProfileService
{
    Task<UserProfile> GetByIdAsync(int id);
    Task<IEnumerable<UserProfile>> GetAllAsync();
    Task AddAsync(UserProfile profile);
    Task UpdateAsync(UserProfile profile);
    Task DeleteAsync(int id);
    Task<UserProfile> GetByUserIdAsync(int userId);
}