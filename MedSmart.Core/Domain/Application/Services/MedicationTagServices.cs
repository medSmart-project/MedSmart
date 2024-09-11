using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using System.Linq.Expressions;

namespace MedSmart.Core.Domain.Application.Services;


public class MedicationTagService : IMedicationTagServices
{
    private readonly IGenericRepository<MedicationTag> _medicationTagRepository;

    public MedicationTagService(IGenericRepository<MedicationTag> medicationTagRepository)
    {
        _medicationTagRepository = medicationTagRepository;
    }

    public async Task AddAsync(MedicationTag medicationTag)
    {
        if (medicationTag == null)
        {
            throw new ArgumentNullException(nameof(medicationTag));
        }

        await _medicationTagRepository.AddAsync(medicationTag);
        await _medicationTagRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(int medicationId, MedicationTag medicationTag)
    {
        if (medicationTag == null)
        {
            throw new ArgumentNullException(nameof(medicationTag));
        }

        var existingMedicationTag = await _medicationTagRepository.FindAsync(x => x.MedicationId == medicationTag.MedicationId && x.TagId == medicationTag.TagId);
        var existingMedicationTag1 = existingMedicationTag?.FirstOrDefault();

        if (existingMedicationTag1 != null)
        {
            existingMedicationTag1.MedicationId = medicationTag.MedicationId;
            existingMedicationTag1.TagId = medicationTag.TagId;

            await _medicationTagRepository.UpdateAsync(existingMedicationTag1);
            await _medicationTagRepository.SaveChangesAsync();
        }
        else
        {
            throw new Exception("MedicationTag not found.");
        }
    }

    public async Task DeleteAsync(int medicationId, int tagId)
    {
        var existingMedicationTag = await _medicationTagRepository.FindAsync(x => x.MedicationId == medicationId && x.TagId == tagId);
        var existingMedicationTag1 = existingMedicationTag?.FirstOrDefault();

        if (existingMedicationTag1 != null)
        {
            await _medicationTagRepository.DeleteAsync(existingMedicationTag1);
            await _medicationTagRepository.SaveChangesAsync();
        }
        else
        {
            throw new Exception("MedicationTag not found.");
        }
    }

    public async Task<MedicationTag?> DetermineMedicationTagAsync(int medicationId, int tagId)
    {
        var existingMedicationTag = await _medicationTagRepository.FindAsync(x => x.MedicationId == medicationId && x.TagId == tagId);
        var existingMedicationTag1 = existingMedicationTag?.FirstOrDefault();

        if (existingMedicationTag1 != null)
        {
            return existingMedicationTag1;
        }

        var newMedicationTag = new MedicationTag
        {
            MedicationId = medicationId,
            TagId = tagId
        };

        await _medicationTagRepository.AddAsync(newMedicationTag);
        await _medicationTagRepository.SaveChangesAsync();

        return newMedicationTag;
    }

    public async Task<IEnumerable<MedicationTag>> FindAsync(Expression<Func<MedicationTag, bool>> predicate)
    {
        var medicationTags = await _medicationTagRepository.FindAsync(predicate);
        if (medicationTags == null)
        {
            throw new Exception("MedicationTag not found.");
        }

        return medicationTags;
    }
}