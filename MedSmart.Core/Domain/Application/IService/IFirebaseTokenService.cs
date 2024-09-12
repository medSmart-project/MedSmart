using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface IFirebaseTokenService
{
    Task<FirebaseToken> GetByIdAsync(int id);
    Task<IEnumerable<FirebaseToken>> GetAllAsync();
    Task AddAsync(FirebaseToken token);
    Task UpdateAsync(FirebaseToken token);
    Task DeleteAsync(int id);
    Task<IEnumerable<FirebaseToken>> GetByUserIdAsync(int userId);
}