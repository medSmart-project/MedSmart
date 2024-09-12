using System.Linq.Expressions;
using AutoMapper;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;

namespace MedSmart.Core.Domain.Application.Services;

public class MedicationCategoryService : IMedicationCategoryService
{
    private readonly IGenericRepository<MedicationCategory> _categoryRepository;
    private readonly IMapper _mapper;

    public MedicationCategoryService(IGenericRepository<MedicationCategory> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task AddCategory(MedicationCategoryDto categoryDto)
    {
        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new ArgumentNullException("category name required");
        }

        var category = _mapper.Map<MedicationCategory>(categoryDto);
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(MedicationCategoryDto categoryDto)
    {
        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new ArgumentNullException("category name required");
        }

        var category = _mapper.Map<MedicationCategory>(categoryDto);
        await _categoryRepository.UpdateAsync(category);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new Exception("Category not found");
        }

        await _categoryRepository.DeleteAsync(category);
        await _categoryRepository.SaveChangesAsync();
        return true;
    }

    public async Task<MedicationCategoryDto?> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<MedicationCategoryDto?>(category);
    }

    public async Task<IEnumerable<MedicationCategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicationCategoryDto>>(categories);
    }

    public async Task<IEnumerable<MedicationCategoryDto>> FindAsync(Expression<Func<MedicationCategory, bool>> predicate)
    {
        var categories = await _categoryRepository.FindAsync(predicate);
        return _mapper.Map<IEnumerable<MedicationCategoryDto>>(categories);
    }

    public async Task<MedicationCategory?> DetermineCategoryAsync(string categoryName)
    {
        var existingCategories = await _categoryRepository.FindAsync(x => x.Name == categoryName);
        var existingCategory = existingCategories?.FirstOrDefault();
        if (existingCategory == null)
        {
            var category = new MedicationCategory
            {
                Name = categoryName
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return _mapper.Map<MedicationCategory?>(category);
        }

        return _mapper.Map<MedicationCategory?>(existingCategory);
    }
}