using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities;

public class FirebaseToken
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required(ErrorMessage = "Token is required.")]
    [StringLength(500, ErrorMessage = "Token cannot exceed 500 characters.")]
    public string Token { get; set; }

    public User User { get; set; }
}