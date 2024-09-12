using MedSmart.Core.Domain.Entities;

namespace MedSmart.Core.Domain.Application.IService;

public interface ITagService
{
    Task<Tag> GetByIdAsync(int id);
    Task<IEnumerable<Tag>> GetAllAsync();
    Task AddAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(int id);
    Task<IEnumerable<Tag>> GetByNameAsync(string name);
}