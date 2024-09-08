using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class MedicationLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MedicationId { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime TakenAt { get; set; }

    public bool IsTakenOnTime { get; set; } = true;

    public User User { get; set; }
    public Medication Medication { get; set; }
}