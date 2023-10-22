using System.ComponentModel.DataAnnotations;

namespace ThrombosisApp.Server.Models;

public class Patient
{
     [Key]
    public int PatientId { get; set; }
     [Required]
     [StringLength(60)]
    public string? FirstName { get; set; }
     [Required]
     [StringLength(60)]
    public string? LastName { get; set; }
     [Required]
    public float INR { get; set; }
    public string? DoseDescription { get; set; }
}