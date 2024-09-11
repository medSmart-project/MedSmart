using Microsoft.AspNetCore.Http;

namespace MedSmart.Core.Domain.Application.DTOs;

public class AddMedicationDto
{
    // Existing properties
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public string Dosage { get; set; }
    public string Usage { get; set; }
    public string SideEffects { get; set; }
    public string Contraindications { get; set; }
    public string ActiveIngredients { get; set; }
    public int StockQuantity { get; set; }
    public bool RequiresPrescription { get; set; }
    public bool IsOverTheCounter { get; set; }
    public DateTime ExpiryDate { get; set; }
    public decimal Weight { get; set; }
    public int SupplierId { get; set; }
    public ICollection<IFormFile> MedicationImages { get; set; }
    public ICollection<string> Tags { get; set; }

    // New discount properties
    public decimal? Discount { get; set; }
    public DateTime? DiscountStartDate { get; set; }
    public DateTime? DiscountEndDate { get; set; }
}