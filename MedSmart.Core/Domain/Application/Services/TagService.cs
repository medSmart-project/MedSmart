using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using System.Linq.Expressions;

namespace MedSmart.Core.Domain.Application.Services;

public class TagService : ITagServices
{
    private readonly IGenericRepository<Tag> _tagRepository;

    public TagService(IGenericRepository<Tag> tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Tag?> DetermineTagAsync(string tagName)
    {
        var existingTags = await _tagRepository.FindAsync(x => x.Name == tagName);
        var existingTag = existingTags?.FirstOrDefault();
        if (existingTag != null)
        {
            return existingTag;
        }

        var newTag = new Tag
        {
            Name = tagName
        };

        await _tagRepository.AddAsync(newTag);
        await _tagRepository.SaveChangesAsync(); // Ensure the tag is saved in the database
        return newTag;
    }

    public async Task<Tag> UpdateAsync(int tagId, string tagName)
    {
        var tag = await _tagRepository.GetByIdAsync(tagId);
        if (tag == null)
        {
            throw new Exception("Tag not found");
        }

        tag.Name = tagName;
        await _tagRepository.UpdateAsync(tag);
        await _tagRepository.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> DeleteAsync(int tagId)
    {
        var tag = await _tagRepository.GetByIdAsync(tagId);
        if (tag == null)
        {
            throw new Exception("Tag not found");
        }

        await _tagRepository.DeleteAsync(tag);
        await _tagRepository.SaveChangesAsync();
        return tag;
    }

    public async Task<IEnumerable<Tag>> FindAsync(Expression<Func<Tag, bool>> predicate)
    {
        return await _tagRepository.FindAsync(predicate);
    }

    public async Task AddAsync(Tag tag)
    {
        await _tagRepository.AddAsync(tag);
        await _tagRepository.SaveChangesAsync();
    }
}