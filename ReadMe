# MedSmart

**MedSmart** is a healthcare management system for managing patient records, tracking medications, and leveraging AI for predictions. It uses ASP.NET Core for the backend and integrates with machine learning models.

## Table of Contents

| Section            | Details                                                       |
|--------------------|---------------------------------------------------------------|
| [Project Overview](#project-overview) | Overview and key features |
| [Installation](#installation)         | Setup instructions        |
| [Configuration](#configuration)       | Configuration details      |
| [Machine Learning Integration](#machine-learning-integration) | Integration with ML models |
| [Testing](#testing)                   | How to run tests           |
| [Deployment](#deployment)             | Deployment instructions    |
| [Contributing](#contributing)         | How to contribute          |
| [License](#license)                   | License information        |
| [Contact](#contact)                   | Contact details            |

## API Endpoints

| Resource        | Method | Endpoint                   | Description                                   |
|-----------------|--------|----------------------------|-----------------------------------------------|
| **Patients**    | POST   | `/api/patients`            | Add a new patient                             |
|                 | PUT    | `/api/patients/{id}`       | Update a patient's details                    |
|                 | DELETE | `/api/patients/{id}`       | Delete a patient                              |
| **Pharmacist**  | POST   | `/api/pharmacist`          | Add a new Pharmacist                          |
|                 | PUT    | `/api/Pharmacist/{id}`     | Update a Pharmacist's details                 |
|                 | DELETE | `/api/Pharmacist/{id}`     | Delete a Pharmacist                           |
| **Medications** | GET    | `/api/medications`         | Get a list of all medications                 |
|                 | POST   | `/api/medications`         | Add a new medication                          |
|                 | PUT    | `/api/medications/{id}`    | Update a medication                           |
|                 | DELETE | `/api/medications/{id}`    | Delete a medication                           |
| **Predictions** | POST   | `/api/Medpredictions`      | Send patient data and receive predictions from the ML model |


## Project Overview

| Aspect              | Details                                                       |
|---------------------|---------------------------------------------------------------|
| **Description**     | Healthcare management system for patient and medication management with AI predictions. |
| **Technology Stack**| ASP.NET Core, SQL Server, Python (Flask/FastAPI)             |
| **Features**        | - Manage patient records <br> - Track medications <br> - AI predictions for health management |

## Installation

| Step                | Command/Details                                            |
|---------------------|------------------------------------------------------------|
| **Clone Repository**| `git clone https://github.com/medSmart-project/MedSmart.git` |
| **Navigate to Project** | `cd MedSmart`                                             |
| **Restore Packages**| `dotnet restore`                                          |
| **Database Setup**  | Configure `appsettings.json`, then run migrations: `dotnet ef database update` |
| **Run Application** | `dotnet run`                                              |

## Configuration

| File                | Purpose                                                    |
|---------------------|------------------------------------------------------------|
| **appsettings.json**| Configure database connection strings and other settings. |

**Example `appsettings.json` Configuration:**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MedSmart; Integrated Security=True; Trust Server Certificate= true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}


## Usage

| Component           | Description                                                                                       | Example                                           |
|---------------------|---------------------------------------------------------------------------------------------------|---------------------------------------------------|
| **Start Application** | Run the application locally.                                                                    | `dotnet run`                                     |
| **API Request**       | Interact with the API endpoints.                                                                  | Use a tool like Postman or cURL to send requests. |
| **Get All Patients**  | Retrieve a list of all patients.                                                                  | `GET /api/patients`                              |
| **Add New Patient**   | Add a new patient to the system.                                                                  | `POST /api/patients` with patient data in JSON format. |
| **Update Patient**    | Update existing patient details.                                                                  | `PUT /api/patients/{id}` with updated patient data in JSON format. |
| **Delete Patient**    | Remove a patient from the system.                                                                 | `DELETE /api/patients/{id}`                      |
| **Get All Medications** | Retrieve a list of all medications.                                                               | `GET /api/medications`                           |
| **Add Medication**    | Add a new medication to the system.                                                                | `POST /api/medications` with medication data in JSON format. |
| **Update Medication** | Update details of an existing medication.                                                         | `PUT /api/medications/{id}` with updated medication data in JSON format. |
| **Delete Medication** | Remove a medication from the system.                                                               | `DELETE /api/medications/{id}`                   |
| **Get Predictions**   | Obtain predictions based on patient data from the ML model.                                        | `POST /api/predictions` with patient data in JSON format. |



## Machine Learning Integration

| Step                       | Description                                                                                       | Command/Details                                                                                     |
|----------------------------|---------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|
| **1. Deploy ML Model**     | Host the ML model using a web framework like Flask or FastAPI. Ensure it exposes an endpoint for predictions. | Example: `http://localhost:5000/predict`                                                           |
| **2. Integrate ML Model**  | Integrate the ML model into your ASP.NET Core application using `HttpClient` to call the model's API endpoint. | Use `HttpClient` to send requests to the ML model service and receive predictions.                 |
| **3. Example Code**        | Include sample code for making API calls to the ML model from your ASP.NET Core application.     | ```csharp<br>var response = await _httpClient.PostAsync("http://localhost:5000/predict", content);<br>``` |
| **4. Test Integration**    | Verify that the integration works correctly by sending sample data and checking the response.   | Send a POST request to `/api/predictions` and verify that it returns the expected results from the ML model. |

### Example of Calling ML Model from ASP.NET Core

```csharp
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MedSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public PredictionController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        [Route("getPrediction")]
        public async Task<IActionResult> GetPrediction([FromBody] PredictionRequest request)
        {
            var jsonData = JsonConvert.SerializeObject(new { features = request.Features });
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Call the external ML model API
            var response = await _httpClient.PostAsync("http://localhost:5000/predict", content);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error calling the ML model service.");
            }

            var predictionResponse = await response.Content.ReadAsStringAsync();
            return Ok(predictionResponse);
        }
    }

    // This is a DTO to hold the prediction request features
    public class PredictionRequest
    {
        public float[] Features { get; set; }
    }
}



### Interfaces

| Interface Name         | Description                                                     |
|------------------------|-----------------------------------------------------------------|
| **IPatientService**    | Defines methods for managing patient data.                      | 
| **IMedicationService** | Defines methods for managing medication data.                   | 
| **IPatientRepository** | Defines methods for accessing patient data from the data source.| 
| **IMedicationRepository** | Defines methods for accessing medication data from the data source. |
| **IDoctorService** | Defines methods for accessing Doctor data from the data source.| 
| **ITagServices** | Defines methods for accessing tags data from the data source.| 
| **ISupplierService** | Defines methods for accessing supplier data from the data source.| 
| **IShippingService** | Defines methods for accessing shipping data from the data source.| 
| **IStockAlertService** | Defines methods for accessing stock data from the data source.| 
| **IReminderService** | Defines methods for accessing reminder data from the data source.| 
| **IReminderSettingsService** | Defines methods for accessing settings for reminder data from the data source.| 
| **IReminderPriorityService** | Defines methods for accessing prioritiy data from the data source.| 
| **IReminderHistoryService** | Defines methods for accessing history data from the data source.| 
| **IRatingService** | Defines methods for accessing rating data from the data source.| 
| **IPrescriptionService** | Defines methods for accessing prescription data from the data source.| 
| **IOrderService** | Defines methods for accessing order methods from the data source.|
| **IOrderStatusService** | Defines methods for accessing status of the order data from the data source.|
| **IOrderDetailService** | Defines methods for accessing details data from the data source.|
| **INotificationLogService** | Defines methods for accessing notification data from the data source.|
| **INotificationChannelService** | Defines methods for accessing notification channel data from the data source.|
| **IMedicationTagService** | Defines methods for accessing medication tag data from the data source.|
| **IMedicationService** | Defines methods for accessing medication data from the data source.|
| **IMedicationSubCategoryService** | Defines methods for accessing medication subcategory data from the data source.|
| **IMedicationsDiscountService** | Defines methods for accessing medication discount from the data source.|
| **IMedicationScheduleService** | Defines methods for accessing medication schedule from the data source.|
| **IMedicationLogService** | Defines methods for accessing medication logs from the data source.|
| **IImageService** | Defines methods for accessing images data from the data source.|
| **IImageTextExtractorService** | Defines methods for accessing image extractor data from the data source.|




