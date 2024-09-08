namespace MedSmart.Core.Domain.Entities;

public class MedicationsDiscount
{
    public int Id { get; set; }
    public int MedicationId { get; set; }
    public decimal Discount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Medication Medication { get; set; }
}