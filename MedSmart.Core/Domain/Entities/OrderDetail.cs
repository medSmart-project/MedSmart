using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int MedicationId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000.")]
    public decimal Price { get; set; }

    public Order Order { get; set; }
    public Medication Medication { get; set; }
}