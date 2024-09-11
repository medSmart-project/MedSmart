namespace MedSmart.Core.Domain.Application.DTOs;

public class MedicationFilter
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Brand { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? MinDiscount { get; set; }
    public decimal? MaxDiscount { get; set; }
    public int? MinRating { get; set; }
    public int? MaxRating { get; set; }
}