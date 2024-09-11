namespace MedSmart.Core.Domain.Application.DTOs;

public class MedicationSubCategoryDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}