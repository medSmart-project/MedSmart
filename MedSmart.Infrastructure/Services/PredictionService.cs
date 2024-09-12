using System.Text;
using Newtonsoft.Json;

public class PredictionService
{
    private readonly HttpClient _httpClient;

    public PredictionService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<double> GetPredictionAsync(double demand, double quantity)
    {
        var requestBody = new
        {
            demand = demand,
            quantity = quantity
        };

        var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("https://maryalaa.pythonanywhere.com/predict", jsonContent);

            // تحقق من نجاح الاستجابة
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var predictionResponse = JsonConvert.DeserializeObject<PredictionResponse>(responseBody);

            return predictionResponse.Prediction;
        }
        catch (HttpRequestException e)
        {
            // عرض تفاصيل الخطأ
            Console.WriteLine($"Error while calling Flask API: {e.Message}");
            throw;
        }
    }

    public class PredictionResponse
    {
        public double Prediction { get; set; }
    }
}