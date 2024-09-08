using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedSmart.Core.Domain.Entities;

public class MedicationTag
{
    [Key]
    [Column(Order = 1)]
    public int MedicationId { get; set; }
    public int TagId { get; set; }

    public Medication? Medication { get; set; }
    public Tag? Tag { get; set; }


}
