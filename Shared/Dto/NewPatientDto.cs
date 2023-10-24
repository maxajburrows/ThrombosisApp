using System.ComponentModel.DataAnnotations;

namespace ThrombosisApp.Shared.Dto;

public class NewPatientDto
{
     [Required]
    public string? FirstName { get; set; }
     [Required]
    public string? LastName { get; set; }
     [Required]
     [Range(0.1, 10, ErrorMessage = "INR value must be between 0.1 and 10")]
    public float INR { get; set; }
}