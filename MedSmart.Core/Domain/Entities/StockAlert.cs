using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class StockAlert
{
    public int Id { get; set; }
    public int MedicationId { get; set; }
    public int UserId { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
    public DateTime AlertTime { get; set; }

    public bool IsNotified { get; set; } = false;

    public Medication Medication { get; set; }
    public User User { get; set; }
}