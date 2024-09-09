namespace MedSmart.Core.Domain.Application.IService;

public interface IImageTextExtractorService
{
    Task<string> ExtractTextFromImageAsync(string imageUrl);

}