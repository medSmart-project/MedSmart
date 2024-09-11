using AutoMapper;
using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;


namespace MedSmart.Core.Domain.Application.Services;

public class c
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
        _context = repositoryFactory.CreateRepository<applicationdbcontext>();
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