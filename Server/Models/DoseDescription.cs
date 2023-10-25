using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThrombosisApp.Server.Models;

public class DoseDescription
{
     [Key]
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int Day { get; set; }
    public float Dose { get; set; }
    //public Patient? Patient { get; set; }
}