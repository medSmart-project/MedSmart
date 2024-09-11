namespace MedSmart.Core.Domain.Application.DTOs;

public class MedicationsDiscountDto
{
    public int Id { get; set; }
    public int MedicationId { get; set; }
    public decimal Discount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}