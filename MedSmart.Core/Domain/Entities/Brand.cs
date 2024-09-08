using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Brand
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters.")]
    public string Country { get; set; }

    public ICollection<Medication> Medications { get; set; } = new List<Medication>();
}