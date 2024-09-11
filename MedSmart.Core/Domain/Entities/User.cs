using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full name is required.")]
    [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    public string Password {  get; set; }

    public UserProfile UserProfile { get; set; }
    
    public ICollection<Rating> Ratings { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<MedicationLog> MedicationLogs { get; set; }
    public ICollection<NotificationLog> NotificationLogs { get; set; }
    public ICollection<StockAlert> StockAlerts { get; set; }
    public ICollection<Reminder> Reminders { get; set; }
    public ICollection<FirebaseToken> FirebaseTokens { get; set; }
    public ReminderSettings ReminderSettings { get; set; }
    public ICollection<HangfireJob> HangfireJobs { get; set; } = new HashSet<HangfireJob>();
}