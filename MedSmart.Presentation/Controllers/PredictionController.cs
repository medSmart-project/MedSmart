using MedSmart.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class PredictionController : ControllerBase
{
    private readonly PredictionService _predictionService;

    public PredictionController()
    {
        _predictionService = new PredictionService();
    }

    // Endpoint: api/prediction
    [HttpPost]
    public async Task<IActionResult> Predict([FromBody] PredictionRequest request)
    {
        try
        {
            // Ensure the request contains the required data
            if (request == null || request.Demand <= 0 || request.Quantity <= 0)
            {
                return BadRequest("Invalid input data.");
            }

            // Call the prediction service
            var prediction = await _predictionService.GetPredictionAsync(request.Demand, request.Quantity);

            // Return the result as JSON
            return Ok(new { prediction });
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            // _logger.LogError(ex, "An error occurred while predicting.");

            // Return a generic error response
            return StatusCode(500, new { error = "An error occurred while processing your request.", details = ex.Message });
        }
    }
}

