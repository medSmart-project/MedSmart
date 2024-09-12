using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSmart.Core.Domain.Application.Services
{
    public class Ratingservice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicationId { get; set; }
        public int RatingValue { get; set; }
        public string Review { get; set; }

    }
}
