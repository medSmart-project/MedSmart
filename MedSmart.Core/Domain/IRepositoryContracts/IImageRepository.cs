using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MedSmart.Core.Domain.IRepositoryContracts;

public interface IImageRepository
{
    

    Task<CloudinaryResult> UploadImageAsync(IFormFile uploadParams);
    Task DeleteImageAsync(string publicId);
    Task AddImageAsync(MedicationImage? image);
    Task<MedicationImage?> GetImageByIdAsync(int id);
    // Task<List<ProductImage?>> GetImageByIdProductIdAsync(int id);
    Task<IEnumerable<ImageDto>> GetImageByProductIdAsync(int productId);
}