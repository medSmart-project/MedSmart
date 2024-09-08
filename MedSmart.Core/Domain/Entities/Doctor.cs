using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Doctor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full name is required.")]
    [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
    public string FullName { get; set; }

    [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
    public string Specialization { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}