using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class ReminderHistory
{
    public int Id { get; set; }
    public int ReminderId { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime SentAt { get; set; }

    public bool IsDelivered { get; set; }

    [StringLength(50, ErrorMessage = "Delivery status cannot exceed 50 characters.")]
    public string DeliveryStatus { get; set; } // e.g., Sent, Delivered, Failed

    public Reminder Reminder { get; set; }
}