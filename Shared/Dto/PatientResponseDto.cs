
namespace ThrombosisApp.Shared.Dto;

public class PatientResponseDto
{
    public int PatientId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public float INR { get; set; }
    public List<DoseDescriptionDto>? DoseDescriptions { get; set; }
}