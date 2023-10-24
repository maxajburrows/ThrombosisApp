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
            DoseDescription = patient.DoseDescription
        };
    }
    public static Patient NewPatientDtoToPatient(NewPatientDto newPatient)
    {
        return new() {
            PatientId = 0,
            FirstName = newPatient.FirstName,
            LastName = newPatient.LastName,
            INR = newPatient.INR
        };
    }
}