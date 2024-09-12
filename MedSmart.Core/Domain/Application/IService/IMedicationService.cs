using MedSmart.Core.Domain.Application.DTOs;

namespace MedSmart.Core.Domain.Application.IService;

public interface IMedicationService
{
    Task AddAsync(AddMedicationDto medicationDto);
    Task UpdateAsync(UpdateMedicationDto medicationDto);
    Task DeleteAsync(int medicationId);
    Task<MedicationDto> GetByIdAsync(int medicationId);
    Task<IEnumerable<MedicationDto>> GetAllAsync();
}