namespace ThrombosisApp.Shared.Dto;
using System.Text.Json.Serialization;



public class PatientResponseDto
{
     //[JsonPropertyName("patientId")]
    public int PatientId { get; set; }
     //[JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
     //[JsonPropertyName("lastName")]
    public string? LastName { get; set; }
     //[JsonPropertyName("inr")]
    public float INR { get; set; }
     //[JsonPropertyName("doseDescription")]
    public string? DoseDescription { get; set; }
}