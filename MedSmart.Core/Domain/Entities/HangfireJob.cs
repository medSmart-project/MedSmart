using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class HangfireJob
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required(ErrorMessage = "Job ID is required.")]
    [StringLength(50, ErrorMessage = "Job ID cannot exceed 50 characters.")]
    public string JobId { get; set; }

    [StringLength(50, ErrorMessage = "Job type cannot exceed 50 characters.")]
    public string JobType { get; set; } // e.g., Reminder, StockAlert

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime ScheduledAt { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime? ExecutedAt { get; set; }

    public bool IsSuccessful { get; set; }

    [StringLength(1000, ErrorMessage = "Error message cannot exceed 1000 characters.")]
    public string ErrorMessage { get; set; }
    public User User { get; set; }
}