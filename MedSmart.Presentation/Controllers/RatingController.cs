using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSmart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService rate;

        public RatingController(IRatingService rate)
        {
            this.rate = rate;
        }
        [HttpPost]
        public ActionResult<Rating> Addrating([FromBody] Rating _rate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFeedback = rate.AddAsync(_rate);

            return CreatedAtAction(nameof(rate.GetByIdAsync), new { id = createdFeedback.Id }, createdFeedback);
        }
        [HttpPost("update/{id}")]
        public async Task< ActionResult> UpdateRating( int id,[FromBody] Rating _rate)
        {
            if (id != _rate.Id)
            {
                return BadRequest("Feedback ID mismatch");
            }

            var existing = rate.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

           await rate.UpdateAsync(id,_rate);

            return NoContent();

        }

        // DELETE: api/feedback/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int id)
        {
            var existingFeedback = rate.GetByIdAsync(id);

            if (existingFeedback == null)
            {
                return NotFound();
            }

            rate.DeleteAsync(id);
            return NoContent();
        }
    }
}
