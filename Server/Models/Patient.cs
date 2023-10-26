using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThrombosisApp.Server.Models;

public class Patient
{     
     [Key]
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientId { get; set; }
     [Required]
     [StringLength(60)]
    public string? FirstName { get; set; }
     [Required]
     [StringLength(60)]
    public string? LastName { get; set; }
     [Required]
    public float INR { get; set; }
    public List<DoseDescription>? DoseDescriptions { get; set; }
}