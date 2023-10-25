namespace ThrombosisApp.Shared.Dto;

public class DoseDescriptionDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int Day { get; set; }
    public float Dose { get; set; }
}