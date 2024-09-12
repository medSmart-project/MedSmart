using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class UserProfileService : IUserProfileService
{
    // Empty implementation
    public async Task<UserProfile> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserProfile>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(UserProfile profile)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(UserProfile profile)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserProfile> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}