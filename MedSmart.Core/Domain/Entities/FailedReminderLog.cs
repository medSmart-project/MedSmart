namespace MedSmart.Core.Domain.Entities;

public class FailedReminderLog
{
    public int Id { get; set; }
    public int ReminderId { get; set; }
    public DateTime FailedAt { get; set; }
    public string FailureReason { get; set; }
}