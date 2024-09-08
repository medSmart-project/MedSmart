using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class NotificationLog
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required(ErrorMessage = "Notification type is required.")]
    [StringLength(50, ErrorMessage = "Notification type cannot exceed 50 characters.")]
    public string NotificationType { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime SentAt { get; set; }

    public bool IsDelivered { get; set; } = false;

    public User User { get; set; }
}