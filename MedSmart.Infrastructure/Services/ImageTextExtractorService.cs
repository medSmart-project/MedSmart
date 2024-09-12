using MedSmart.Core.Domain.Application.IService;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace MedSmart.Infrastructure.Services;

public class ImageTextExtractorService : IImageTextExtractorService
{
    private readonly string _subscriptionKey;
    private readonly string _endpoint;

    public ImageTextExtractorService(string subscriptionKey, string endpoint)
    {
        _subscriptionKey = subscriptionKey;
        _endpoint = endpoint;
    }

    public async Task<string> ExtractTextFromImageAsync(string imageUrl)
    {
        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(_subscriptionKey))
        {
            Endpoint = _endpoint
        };

        var ocrResult = await client.RecognizePrintedTextAsync(true, imageUrl);

        var extractedText = string.Join(" ",
            ocrResult.Regions.SelectMany(r => r.Lines.SelectMany(l => l.Words.Select(w => w.Text))));

        return extractedText;
    }
}