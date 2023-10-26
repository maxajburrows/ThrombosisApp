using System.ComponentModel.DataAnnotations;

namespace ThrombosisApp.Shared.Dto;

public class EditPatientDto
{
     [Required]
    public int PatientId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
     [Range(0, 10, ErrorMessage = "INR value must be between 0.1 and 10")] //This validation needs attention
    public float INR { get; set; }
}