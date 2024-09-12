using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface ICommentService
{
    Task<Comment> GetByIdAsync(int id);
    Task<IEnumerable<Comment>> GetAllAsync();
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(int id);
    Task<IEnumerable<Comment>> GetByUserIdAsync(int userId);
}