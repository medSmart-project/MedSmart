using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Prescription
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DoctorId { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime PrescriptionDate { get; set; }

    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters.")]
    public string Notes { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime ValidUntil { get; set; }

    public User User { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<MedicationSchedule> MedicationSchedules { get; set; }
}