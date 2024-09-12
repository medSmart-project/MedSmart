using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class FirebaseTokenService : IFirebaseTokenService
{
    // Empty implementation
    public async Task<FirebaseToken> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FirebaseToken>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(FirebaseToken token)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(FirebaseToken token)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FirebaseToken>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}