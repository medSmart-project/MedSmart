using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedSmart.Core.Domain.Entities
{
    public class Medication
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000.")]
        public decimal Price { get; set; }

        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Dosage is required.")]
        [StringLength(50, ErrorMessage = "Dosage cannot exceed 50 characters.")]
        public string Dosage { get; set; }

        [StringLength(500, ErrorMessage = "Usage cannot exceed 500 characters.")]
        public string Usage { get; set; }

        [StringLength(500, ErrorMessage = "Side effects cannot exceed 500 characters.")]
        public string SideEffects { get; set; }

        [StringLength(500, ErrorMessage = "Contraindications cannot exceed 500 characters.")]
        public string Contraindications { get; set; }

        [Required(ErrorMessage = "Active ingredients are required.")]
        [StringLength(200, ErrorMessage = "Active ingredients cannot exceed 200 characters.")]
        public string ActiveIngredients { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative integer.")]
        public int StockQuantity { get; set; }

        public bool RequiresPrescription { get; set; }
        public bool IsOverTheCounter { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime ExpiryDate { get; set; }

        [Range(0.01, 1000, ErrorMessage = "Weight must be between 0.01 and 1000.")]
        public decimal Weight { get; set; }
        public int SupplierId { get; set; }

        public Brand Brand { get; set; }
        public MedicationCategory Category { get; set; }
        public ICollection<MedicationImage> Images { get; set; }
        public ICollection<MedicationSchedule> MedicationSchedules { get; set; }
        public ICollection<StockAlert> StockAlerts { get; set; }
        public ICollection<MedicationLog> MedicationLogs { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public MedicationsDiscount MedicationsDiscounts { get; set; }
        public ICollection<MedicationTag>  MedicationTags { get; set; }
        
        public ICollection<OrderDetail> OrderDetails { get; set; }
       
        public Supplier Supplier { get; set; }
    }
}
