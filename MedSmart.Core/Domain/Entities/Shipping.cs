using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Shipping
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Shipping method is required.")]
    [StringLength(100, ErrorMessage = "Shipping method cannot exceed 100 characters.")]
    public string ShippingMethod { get; set; }

    [Range(0.01, 1000, ErrorMessage = "Cost must be between 0.01 and 1000.")]
    public decimal Cost { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime EstimatedDeliveryDate { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}