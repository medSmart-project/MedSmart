using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Reminder
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MedicationId { get; set; }

    [Required(ErrorMessage = "Reminder type is required.")]
    [StringLength(50, ErrorMessage = "Reminder type cannot exceed 50 characters.")]
    public string ReminderType { get; set; } // e.g., Push Notification, Email, SMS

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime ReminderTime { get; set; }

    [StringLength(50, ErrorMessage = "Repeat frequency cannot exceed 50 characters.")]
    public string RepeatFrequency { get; set; } // e.g., Daily, Weekly, Monthly

    public bool IsActive { get; set; } = true;
    public bool IsSnoozed { get; set; } = false;
    public TimeSpan? SnoozeDuration { get; set; }
    public bool IsSkipped { get; set; } = false;

    public User User { get; set; }
    public Medication Medication { get; set; }
    public ICollection<ReminderHistory> ReminderHistories { get; set; }
}