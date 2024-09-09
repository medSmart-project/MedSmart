// src/Web/Controllers/ImageController.cs

using MedSmart.Core.Domain.Application.DTOs;
using MedSmart.Core.Domain.Application.IService;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageTextExtractorService _imageTextExtractorService;

    public ImageController(IImageTextExtractorService imageTextExtractorService)
    {
        _imageTextExtractorService = imageTextExtractorService;
    }

    [HttpPost]
    public async Task<IActionResult> ExtractTextFromImage([FromBody] ImageUrlRequest request)
    {
        if (string.IsNullOrEmpty(request.ImageUrl))
            return BadRequest("Image URL is required.");

        try
        {
            var extractedText = await _imageTextExtractorService.ExtractTextFromImageAsync(request.ImageUrl);
            return Ok(new { Text = extractedText });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error processing image: {ex.Message}");
        }
    }
}