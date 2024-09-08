using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class OrderStatus
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string Name { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}