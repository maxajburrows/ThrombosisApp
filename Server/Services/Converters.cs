using ThrombosisApp.Shared.Dto;
using ThrombosisApp.Server.Models;



namespace ThrombosisApp.Server.Services;

public class Converters
{
    public static PatientResponseDto ToPatientResponseDto(Patient patient)
    {
        return new() {
            PatientId = patient.PatientId,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            INR = patient.INR,
            DoseDescriptions = Converters.ToDoseDescriptionDto(patient.DoseDescriptions)
        };
    }
    public static Patient NewPatientDtoToPatient(NewPatientDto newPatient)
    {
        return new() {
            PatientId = 0,
            FirstName = newPatient.FirstName,
            LastName = newPatient.LastName,
            INR = newPatient.INR,
            DoseDescriptions = BuildDoseDescription(newPatient)
        };
    }
    public static List<DoseDescriptionDto> ToDoseDescriptionDto(List<DoseDescription> doses)
    {
        List<DoseDescriptionDto> dtos = new();
        if (doses is null) return dtos;
        foreach (DoseDescription dose in doses)
        {
            DoseDescriptionDto dto = new() { Id = dose.Id, PatientId = dose.PatientId, Day = dose.Day, Dose = dose.Dose};
            dtos.Add(dto);
        }
        return dtos;
    }
    public static DoctorResponseDto ToDoctorResponseDto(Doctor doctor)
    {
        return new() {
            DoctorId = doctor.DoctorId,
            FullName = doctor.FullName,
            Postion = doctor.Postion,
            Tenure = doctor.Tenure
        };
    }
    public static List<DoseDescription> BuildDoseDescription(NewPatientDto newPatient)
    {
        return Enumerable.Range(1, 30)
                    .Select(i => new DoseDescription { 
                            Id = 0,
                            PatientId = 0,
                            Day = i,
                            Dose = CalculateDose(newPatient.INR, i) 
                            }).ToList();
    }
    public static float CalculateDose(float INR, int day)
    {
        double dose = Math.Max(2+(3-INR)*3, 0)*Math.Pow(0.95, day);
        return (float) Math.Round(dose, 2);
    }
}