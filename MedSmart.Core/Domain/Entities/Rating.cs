using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Rating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MedicationId { get; set; }

    [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
    public int RatingValue { get; set; }

    [StringLength(1000, ErrorMessage = "Review cannot exceed 1000 characters.")]
    public string Review { get; set; }

    public User User { get; set; }
    public Medication Medication { get; set; }
}