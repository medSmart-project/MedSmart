using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.Services;

public class CommentService : ICommentService
{
    // Empty implementation
    public async Task<Comment> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Comment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Comment>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}