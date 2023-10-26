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
            //DoseDescription = PatientsService.CalculateDose(newPatient.INR)
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
}