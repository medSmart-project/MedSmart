using System.Linq.Expressions;
using AutoMapper;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;

namespace MedSmart.Core.Domain.Application.Services;

public class DiscountService : IMedicationsDiscountService
{
    private readonly IGenericRepository<MedicationsDiscount> _discountRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DiscountService(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _discountRepository = repositoryFactory.CreateRepository<Discount>();
        _productRepository = repositoryFactory.CreateRepository<Product>();
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicationsDiscountDto>> GetAllAsync()
    {
        var discounts = await _discountRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicationsDiscountDto>>(discounts);
    }

    public async Task<MedicationsDiscountDto?> GetByIdAsync(int id)
    {
        var discount = await _discountRepository.GetByIdAsync(id);
        if (discount == null)
        {
            throw new Exception("Discount not found.");
        }

        return _mapper.Map<MedicationsDiscountDto?>(discount);
    }

    public async Task AddAsync(MedicationsDiscountDto discountDto)
    {
        ValidateDiscount(discountDto);

        var product = await _productRepository.GetByIdAsync(discountDto.ProductId);
        if (product == null)
        {
            throw new InvalidOperationException("Product does not exist.");
        }

        var existingDiscounts = await _discountRepository.FindAsync(d => d.ProductId == discountDto.ProductId);
        if (existingDiscounts.Any())
        {
            throw new InvalidOperationException("A discount already exists for this product.");
        }

        var newDiscount = _mapper.Map<MedicationsDiscount>(discountDto);
        await _discountRepository.AddAsync(newDiscount);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, MedicationsDiscountDto discountDto)
    {
        ValidateDiscount(discountDto);

        var existingDiscount = await _discountRepository.GetByIdAsync(id);
        if (existingDiscount == null)
        {
            throw new Exception("Discount not found.");
        }

        _mapper.Map(discountDto, existingDiscount);
        await _discountRepository.UpdateAsync(existingDiscount);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var discount = await _discountRepository.GetByIdAsync(id);
        if (discount == null)
        {
            throw new Exception("Discount not found.");
        }

        await _discountRepository.DeleteAsync(discount);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<MedicationsDiscountDto>> FindAsync(Expression<Func<MedicationsDiscount, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MedicationsDiscountDto>> FindAsync(Expression<Func<Discount, bool>> predicate)
    {
        var discounts = await _discountRepository.FindAsync(predicate);
        return _mapper.Map<IEnumerable<MedicationsDiscountDto>>(discounts);
    }

    private void ValidateDiscount(MedicationsDiscountDto discountDto)
    {
        if (discountDto.Discount <= 0)
        {
            throw new ArgumentException("Discount amount must be greater than zero.");
        }

        if (discountDto.StartDate >= discountDto.EndDate)
        {
            throw new ArgumentException("Start date must be earlier than end date.");
        }

        if (discountDto.ProductId <= 0)
        {
            throw new ArgumentException("Invalid product ID.");
        }

        if (discountDto.StartDate < DateTime.UtcNow)
        {
            throw new ArgumentException("Start date cannot be in the past.");
        }

        if (discountDto.EndDate < DateTime.UtcNow)
        {
            throw new ArgumentException("End date cannot be in the past.");
        }
    }

    public async Task DeleteExpiredDiscountsAsync()
    {
        await _unitOfWork.DeleteExpiredDiscountsAsync();
    }
}