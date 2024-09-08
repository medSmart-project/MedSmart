using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Supplier
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Contact info cannot exceed 500 characters.")]
    public string ContactInfo { get; set; }

    [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
    public string Address { get; set; }

    public ICollection<Medication> Medications { get; set; } = new List<Medication>();
}