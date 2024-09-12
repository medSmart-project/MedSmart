using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using MedSmart.Core.Domain.IRepositoryContracts;
using Microsoft.AspNetCore.Http;

namespace MedSmart.Core.Domain.Application.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
    }

    public async Task<CloudinaryResult> UploadImageAsync(IFormFile uploadParams)
    {
        return await _imageRepository.UploadImageAsync(uploadParams);



    }

    public async Task DeleteImageAsync(string publicId)
    {
        await _imageRepository.DeleteImageAsync(publicId);
    }

    public async Task AddImageAsync(MedicationImage? image)
    {
        await _imageRepository.AddImageAsync(image);
    }

    public async Task<MedicationImage?> GetImageByIdAsync(int id)
    {
        return await _imageRepository.GetImageByIdAsync(id);
    }

    public Task<IEnumerable<ImageDto>> GetImageByProductIdAsync(int id)
    {

        return _imageRepository.GetImageByProductIdAsync(id);
    }
}