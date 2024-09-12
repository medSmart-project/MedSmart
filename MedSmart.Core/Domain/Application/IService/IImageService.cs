using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MedSmart.Core.Domain.Application.IService;

public interface IImageService
{
    Task<CloudinaryResult> UploadImageAsync(IFormFile uploadParams);
    Task DeleteImageAsync(string publicId);
    Task AddImageAsync(MedicationImage? image);
    Task<MedicationImage?> GetImageByIdAsync(int id);
    Task<IEnumerable<ImageDto>> GetImageByProductIdAsync(int id);
}