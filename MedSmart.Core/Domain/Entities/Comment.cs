using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MedicationId { get; set; }

    [Required(ErrorMessage = "Text is required.")]
    [StringLength(1000, ErrorMessage = "Text cannot exceed 1000 characters.")]
    public string Text { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime PostedAt { get; set; }

    public User User { get; set; }
    public Medication Medication { get; set; }
}