namespace MedSmart.Core.Domain.Application.DTOs;

public class CloudinaryResult
{
    [System.ComponentModel.DataAnnotations.Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public string PublicId { get; set; }
}