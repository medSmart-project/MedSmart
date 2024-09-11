using MedSmart.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourNamespace.Services;  // Add your service namespace
using YourNamespace.Models;   // Add your models namespace

namespace YourNamespace.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PatientController : ControllerBase
        {
            private readonly MedicationRepository medicationrepo;

            public PatientController(MedicationRepository _medicationrepo)
            {

                medicationrepo = _medicationrepo;
            }
            [HttpGet("index")]
            public async Task<IActionResult> Index()
            {
                var topselling = await medicationrepo.GetTopSellingMedicationsAsync();
                var newest = await medicationrepo.GetNewestMedicationsAsync();
                var featured = await medicationrepo.GetFeaturedMedicationsAsync();
                var model = new
                {
                    TopSellingMedication = topselling,
                    NewestMedication = newest,
                    FeaturedMedication = featured
                };

                return Ok(model);

            }
            [HttpGet("search")]
            public async Task<IActionResult> Search(string searchTerm)
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return Ok(new List<Medication>());
                }

                var medications = await medicationrepo.SearchMedicationsAsync(searchTerm);
                return Ok(medications);
            }

            [HttpGet("medications-on-sale")]
            public async Task<IActionResult> MedicationsOnSale()
            {
                var medicationsOnSale = await medicationrepo.GetMedicationsOnSaleAsync();
                return Ok(medicationsOnSale);
            }


            [HttpGet("medications-by-supplier/{supplierId}")]
            public async Task<IActionResult> MedicationsBySupplier(int supplierId)
            {
                var medicationsBySupplier = await medicationrepo.GetMedicationsBySupplierAsync(supplierId);
                return Ok(medicationsBySupplier);
            }


            [HttpGet("out-of-stock-medications")]
            public async Task<IActionResult> OutOfStockMedications()
            {
                var outOfStockMedications = await medicationrepo.GetOutOfStockMedicationsAsync();
                return Ok(outOfStockMedications);
            }
            [HttpGet("recommended-medications")]
            public async Task<IActionResult> RecommendedMedications()
            {
                var recommendedMedications = await medicationrepo.GetRecommendedMedicationsAsync();
                return Ok(recommendedMedications);
            }


            [HttpGet("similar-or-related-medications/{medicationId}")]
            public async Task<IActionResult> SimilarOrRelatedMedications(int medicationId, bool related = false)
            {
                var similarOrRelatedMedications = await medicationrepo.GetSimilarOrRelatedMedicationsAsync(medicationId, related);
                return Ok(similarOrRelatedMedications);
            }
        }
    }
}
