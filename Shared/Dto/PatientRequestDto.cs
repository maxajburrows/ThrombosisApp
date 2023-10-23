namespace ThrombosisApp.Shared.Dto;

public class PatientRequestDto
{
    public int PatientId { get; set; } = 0;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public float INR { get; set; }
    public string? DoseDescription { get; set; }
}