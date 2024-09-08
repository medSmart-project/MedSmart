using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class ReminderSettings
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public bool EmailNotifications { get; set; }
    public bool SmsNotifications { get; set; }
    public bool PushNotifications { get; set; }

    [DataType(DataType.Time, ErrorMessage = "Invalid time format.")]
    public TimeSpan PreferredTime { get; set; }

    public User User { get; set; }
}