using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [StringLength(100, ErrorMessage = "Preferred pharmacy cannot exceed 100 characters.")]
    public string PreferredPharmacy { get; set; }

    [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
    public string Address { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime DateOfBirth { get; set; }

    public User User { get; set; }
}