using MedSmart.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationTagServices
{

    Task AddAsync(MedicationTag medicationTag);
    Task UpdateAsync(int medicationId, MedicationTag medicationTag);
    Task DeleteAsync(int medicationId, int tagId);
    Task<MedicationTag?> DetermineMedicationTagAsync(int medicationId, int tagId);
    Task<IEnumerable<MedicationTag>> FindAsync(Expression<Func<MedicationTag, bool>> predicate);
}
