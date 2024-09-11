using System.Linq.Expressions;
using AutoMapper;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;

namespace MedSmart.Core.Domain.Application.Services;

public class MedicationSubCategoryService : IMedicationSubCategoryService
{
    private readonly IGenericRepository<MedicationSubCategory> _subCategoryRepository;
    private readonly IMapper _mapper;

    public MedicationSubCategoryService(IGenericRepository<MedicationSubCategory> subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task AddSubCategory(MedicationSubCategoryDto subCategoryDto)
    {
        if (string.IsNullOrEmpty(subCategoryDto.Name))
        {
            throw new ArgumentNullException("subcategory name required");
        }

        var subCategory = _mapper.Map<MedicationSubCategory>(subCategoryDto);
        await _subCategoryRepository.AddAsync(subCategory);
        await _subCategoryRepository.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(MedicationSubCategoryDto subCategoryDto)
    {
        if (string.IsNullOrEmpty(subCategoryDto.Name))
        {
            throw new ArgumentNullException("subcategory name required");
        }

        var subCategory = _mapper.Map<MedicationSubCategory>(subCategoryDto);
        await _subCategoryRepository.UpdateAsync(subCategory);
        await _subCategoryRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var subCategory = await _subCategoryRepository.GetByIdAsync(id);
        if (subCategory == null)
        {
            throw new Exception("SubCategory not found");
        }

        await _subCategoryRepository.DeleteAsync(subCategory);
        await _subCategoryRepository.SaveChangesAsync();
        return true;
    }

    public async Task<MedicationSubCategoryDto?> GetByIdAsync(int id)
    {
        var subCategory = await _subCategoryRepository.GetByIdAsync(id);
        return _mapper.Map<MedicationSubCategoryDto?>(subCategory);
    }

    public async Task<IEnumerable<MedicationSubCategoryDto>> GetAllAsync()
    {
        var subCategories = await _subCategoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicationSubCategoryDto>>(subCategories);
    }

    public async Task<IEnumerable<MedicationSubCategoryDto>> FindAsync(Expression<Func<MedicationSubCategory, bool>> predicate)
    {
        var subCategories = await _subCategoryRepository.FindAsync(predicate);
        return _mapper.Map<IEnumerable<MedicationSubCategoryDto>>(subCategories);
    }

    public async Task<MedicationSubCategory?> DetermineSubCategoryAsync(string subCategoryName)
    {
        var existingSubCategories = await _subCategoryRepository.FindAsync(x => x.Name == subCategoryName);
        var existingSubCategory = existingSubCategories?.FirstOrDefault();
        if (existingSubCategory == null)
        {
            var subCategory = new MedicationSubCategory
            {
                Name = subCategoryName
            };
            await _subCategoryRepository.AddAsync(subCategory);
            await _subCategoryRepository.SaveChangesAsync();
            return _mapper.Map<MedicationSubCategory?>(subCategory);
        }

        return _mapper.Map<MedicationSubCategory?>(existingSubCategory);
    }
}