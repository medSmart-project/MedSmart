using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime OrderDate { get; set; }

    public int OrderStatusId { get; set; }
    public int ShippingId { get; set; }

    [Range(0.01, 100000, ErrorMessage = "Total price must be between 0.01 and 100000.")]
    public decimal TotalPrice { get; set; }

    [Required(ErrorMessage = "Shipping address is required.")]
    [StringLength(500, ErrorMessage = "Shipping address cannot exceed 500 characters.")]
    public string ShippingAddress { get; set; }

    public User Customer { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public Shipping Shipping { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}