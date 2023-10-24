namespace ThrombosisApp.Shared.Dto;
using System.Text.Json.Serialization;

public class PatientResponseDto
{
    public int PatientId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public float INR { get; set; }
    public string? DoseDescription { get; set; }
}