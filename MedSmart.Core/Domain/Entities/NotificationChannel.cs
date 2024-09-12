namespace MedSmart.Core.Domain.Entities;

public class NotificationChannel
{
    public int Id { get; set; }
    public string ChannelName { get; set; } 
    public bool IsEnabled { get; set; }
}