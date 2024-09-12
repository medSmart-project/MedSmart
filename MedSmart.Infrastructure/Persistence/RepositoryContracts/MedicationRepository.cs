using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class MedicationRepository : IMedicationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IGenericRepository<Medication> _repository;

    public MedicationRepository(ApplicationDbContext context, IGenericRepository<Medication> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<IEnumerable<Medication>> GetMedicationsByFilterAsync(MedicationFilter filter)
    {

        var query = _context.Medications.Include(m => m.Images).AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(m => m.Name.Contains(filter.Name));
        }

        if (!string.IsNullOrEmpty(filter.Category))
        {
            query = query.Where(m => m.Category.Name == filter.Category);
        }

        if (!string.IsNullOrEmpty(filter.Brand))
        {
            query = query.Where(m => m.Brand.Name == filter.Brand);
        }

        if (filter.MinPrice.HasValue)
        {
            query = query.Where(m => m.Price >= filter.MinPrice.Value);
        }

        if (filter.MaxPrice.HasValue)
        {
            query = query.Where(m => m.Price <= filter.MaxPrice.Value);
        }

        if (filter.MinDiscount.HasValue)
        {
            query = query.Where(m => m.MedicationsDiscounts.Discount >= filter.MinDiscount.Value);
        }

        if (filter.MaxDiscount.HasValue)
        {
            query = query.Where(m => m.MedicationsDiscounts.Discount <= filter.MaxDiscount.Value);
        }

        if (filter.MinRating.HasValue)
        {
            query = query.Where(m => m.Ratings.Average(r => r.RatingValue) >= filter.MinRating.Value);
        }

        if (filter.MaxRating.HasValue)
        {
            query = query.Where(m => m.Ratings.Average(r => r.RatingValue) <= filter.MaxRating.Value);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Medication>> SearchMedicationsAsync(string searchTerm)
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .Include(m => m.MedicationTags)
            .Where(m => m.Name.Contains(searchTerm)
                        || m.Brand.Name.Contains(searchTerm)
                        || m.Category.Name.Contains(searchTerm)
                        || m.MedicationTags.Any(mt => mt.Tag.Name.Contains(searchTerm)))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetTopSellingMedicationsAsync()
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .OrderByDescending(m => m.OrderDetails.Count)
            .Take(10)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetNewestMedicationsAsync()
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .OrderByDescending(m => m.CreatedAt)
            .Take(10)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetFeaturedMedicationsAsync()
    {
        throw new NotImplementedException();
    }

    //public async Task<IEnumerable<Medication>> GetFeaturedMedicationsAsync()
    //{
    //    return await _context.Medications
    //        .Include(m => m.Brand)
    //        .Include(m => m.Category)
    //        .Include(m => m.Images)
    //        .Where(m => m.IsFeatured)
    //        .Take(10)
    //        .AsNoTracking()
    //        .ToListAsync();
    //}

    public async Task<IEnumerable<Medication>> GetMedicationsOnSaleAsync()
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Images)
            .Include(m => m.Category)
            .Include(m => m.MedicationsDiscounts)
            .Where(m => m.MedicationsDiscounts.Discount > 0)
            .AsNoTracking()


            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetMedicationsBySupplierAsync(int supplierId)
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .Where(m => m.SupplierId == supplierId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetOutOfStockMedicationsAsync()
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .Where(m => m.StockQuantity == 0)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetRecommendedMedicationsAsync()
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .Where(m => m.Ratings.Average(r => r.RatingValue) >= 4)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Medication>> GetSimilarOrRelatedMedicationsAsync(int medicationId, bool related = false)
    {
        var medication = await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == medicationId);

        if (medication == null)
        {
            return Enumerable.Empty<Medication>();
        }

        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Images)
            .Where(m => related ? m.CategoryId == medication.CategoryId : m.BrandId == medication.BrandId)
            .AsNoTracking()
            .ToListAsync();
    }

    //public async Task<IEnumerable<MedicationCardDto>> GetMedicationCards()
    //{
    //    return await _context.Medications
    //        .Include(m => m.Brand)
    //        .Include(m => m.Category)
    //        .Include(m => m.Images)
    //        .Select(m => new MedicationCardDto
    //        {
    //            Id = m.Id,
    //            Name = m.Name,
    //            Price = m.Price,
    //            ImageUrl = m.MedicationImages.FirstOrDefault().ImageUrl
    //        })
    //        .AsNoTracking()
    //        .ToListAsync();
    //}

    //public async Task<IEnumerable<MedicationDetailDto>> GetMedications()
    //{
    //    return await _context.Medications
    //        .Include(m => m.Brand)
    //        .Include(m => m.Category)
    //        .Include(m => m.MedicationImages)
    //        .Select(m => new MedicationDetailDto
    //        {
    //            Id = m.Id,
    //            Name = m.Name,
    //            Price = m.Price,
    //            ImageUrl = m.MedicationImages.FirstOrDefault()!.ImageUrl,
    //            Brand = m.Brand.Name,
    //            Category = m.Category.Name
    //        })
    //        .AsNoTracking()
    //        .ToListAsync();
    //}

    public async Task<Medication> GetByIdAsync(int id)
    {
        return await _context.Medications
            .Include(m => m.Brand)
            .Include(m => m.Category)
            .Include(m => m.Supplier)
            .Include(m => m.MedicationTags).ThenInclude(mt => mt.Tag)
            //   .Include(m => m.MedicationAttributeValues).ThenInclude(mav => mav.MedicationAttribute)
            .Include(m => m.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}