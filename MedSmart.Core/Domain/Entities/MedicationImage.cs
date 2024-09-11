using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class MedicationImage
{
    public int Id { get; set; }
    public int MedicationId { get; set; }

    [Required(ErrorMessage = "Image URL is required.")]
    [Url(ErrorMessage = "Invalid URL format.")]
    public string? ImageUrl { get; set; }


    public string PublicId { get; set; }
    public Medication Medication { get; set; }
}