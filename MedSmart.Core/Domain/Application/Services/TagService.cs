using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using System.Linq.Expressions;

namespace MedSmart.Core.Domain.Application.Services;

public class TagService : ITagServices
{
    private readonly IGenericRepository<Tag> _tagRepository;

    public TagService(IGenericRepository<Tag> tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Tag?> DetermineTagAsync(string tagName)
    {
        var existingTags = await _tagRepository.FindAsync(x => x.Name == tagName);
        var existingTag = existingTags?.FirstOrDefault();
        if (existingTag != null)
        {
            return existingTag;
        }

        var newTag = new Tag
        {
            Name = tagName
        };

        await _tagRepository.AddAsync(newTag);
        await _tagRepository.SaveChangesAsync(); // Ensure the tag is saved in the database
        return newTag;
    }

    public async Task<Tag> UpdateAsync(int tagId, string tagName)
    {
        var tag = await _tagRepository.GetByIdAsync(tagId);
        if (tag == null)
        {
            throw new Exception("Tag not found");
        }

        tag.Name = tagName;
        await _tagRepository.UpdateAsync(tag);
        await _tagRepository.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> DeleteAsync(int tagId)
    {
        var tag = await _tagRepository.GetByIdAsync(tagId);
        if (tag == null)
        {
            throw new Exception("Tag not found");
        }

        await _tagRepository.DeleteAsync(tag);
        await _tagRepository.SaveChangesAsync();
        return tag;
    }

    public async Task<IEnumerable<Tag>> FindAsync(Expression<Func<Tag, bool>> predicate)
    {
        return await _tagRepository.FindAsync(predicate);
    }

    public async Task AddAsync(Tag tag)
    {
        await _tagRepository.AddAsync(tag);
        await _tagRepository.SaveChangesAsync();
    }
<<<<<<< HEAD
}
=======
}

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


using AutoMapper;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedSmart.Core.Domain.Application.Services
{
    public class MedicationService
    {
        private readonly IGenericRepository<Medication> _medicationRepository;
        private readonly IGenericRepository<MedicationImage> _medicationImageRepository;
        private readonly IGenericRepository<MedicationTag> _medicationTagRepository;
        private readonly IGenericRepository<MedicationsDiscount> _discountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ITagService _tagService;

        public MedicationService(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService, ITagService tagService)
        {
            _medicationRepository = repositoryFactory.CreateRepository<Medication>();
            _medicationImageRepository = repositoryFactory.CreateRepository<MedicationImage>();
            _medicationTagRepository = repositoryFactory.CreateRepository<MedicationTag>();
            _discountRepository = repositoryFactory.CreateRepository<MedicationsDiscount>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
            _tagService = tagService;
        }

        public async Task AddAsync(AddMedicationDto medicationDto)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    // Map AddMedicationDto to Medication entity
                    var newMedication = _mapper.Map<Medication>(medicationDto);
                    //  newMedication = DateTime.Now;

                    // Add the medication to the repository
                    await _medicationRepository.AddAsync(newMedication);
                    await _unitOfWork.SaveChangesAsync();

                    // Handle medication images
                    if (medicationDto.MedicationImages != null && medicationDto.MedicationImages.Any())
                    {
                        foreach (var formFile in medicationDto.MedicationImages)
                        {
                            var uploadResult = await _imageService.UploadImageAsync(formFile);
                            if (uploadResult == null)
                            {
                                throw new Exception("Image upload failed.");
                            }
                            var medicationImage = _mapper.Map<MedicationImage>(uploadResult);
                            medicationImage.MedicationId = newMedication.Id;
                            await _medicationImageRepository.AddAsync(medicationImage);
                        }
                    }

                    // Handle medication tags
                    if (medicationDto.Tags != null && medicationDto.Tags.Any())
                    {
                        foreach (var tag in medicationDto.Tags)
                        {
                            var tagEntity = await _tagService.DetermineTagAsync(tag);

                            var medicationTag = new MedicationTag
                            {
                                MedicationId = newMedication.Id,
                                TagId = tagEntity.Id
                            };
                            await _medicationTagRepository.AddAsync(medicationTag);
                        }
                    }

                    // Handle medication discount
                    if (medicationDto.Discount.HasValue && medicationDto.DiscountStartDate.HasValue && medicationDto.DiscountEndDate.HasValue)
                    {
                        ValidateDiscount(medicationDto);

                        var newDiscount = new MedicationsDiscount
                        {
                            MedicationId = newMedication.Id,
                            Discount = medicationDto.Discount.Value,
                            StartDate = medicationDto.DiscountStartDate.Value,
                            EndDate = medicationDto.DiscountEndDate.Value
                        };
                        await _discountRepository.AddAsync(newDiscount);
                    }

                    await _unitOfWork.SaveChangesAsync();
                    await _unitOfWork.CommitTransactionAsync();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw new Exception("Error occurred while adding medication: " + ex.Message, ex);
                }
            }
        }

        private void ValidateDiscount(AddMedicationDto medicationDto)
        {
            if (medicationDto.Discount <= 0)
            {
                throw new ArgumentException("Discount amount must be greater than zero.");
            }

            if (medicationDto.DiscountStartDate >= medicationDto.DiscountEndDate)
            {
                throw new ArgumentException("Start date must be earlier than end date.");
            }

            if (medicationDto.DiscountStartDate < DateTime.UtcNow)
            {
                throw new ArgumentException("Start date cannot be in the past.");
            }

            if (medicationDto.DiscountEndDate < DateTime.UtcNow)
            {
                throw new ArgumentException("End date cannot be in the past.");
            }
        }
    }
}
>>>>>>> origin/master
