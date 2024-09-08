using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class MedicationSchedule
{
    public int Id { get; set; }
    public int PrescriptionId { get; set; }
    public int MedicationId { get; set; }

    [Required(ErrorMessage = "Dosage is required.")]
    [StringLength(50, ErrorMessage = "Dosage cannot exceed 50 characters.")]
    public string Dosage { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime TimeToTake { get; set; }

    public bool IsTaken { get; set; } = false;

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime? TakenAt { get; set; }

    public Prescription Prescription { get; set; }
    public Medication Medication { get; set; }
}