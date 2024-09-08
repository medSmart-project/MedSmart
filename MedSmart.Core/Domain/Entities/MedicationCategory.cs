using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class MedicationCategory
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

    public ICollection<MedicationSubCategory> SubCategories { get; set; } = new List<MedicationSubCategory>();
    public ICollection<Medication> Medications { get; set; } = new List<Medication>();
}