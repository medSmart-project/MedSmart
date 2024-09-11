using MedSmart.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MedSmart.Core.Domain.Application.IService;

public interface ITagServices
{

    Task<Tag?> DetermineTagAsync(string tagName);
    Task<Tag> UpdateAsync(int tagId, string tagName);
    Task<Tag> DeleteAsync(int tagId);
    Task<IEnumerable<Tag>> FindAsync(Expression<Func<Tag, bool>> predicate);
    Task AddAsync(Tag tag);
}