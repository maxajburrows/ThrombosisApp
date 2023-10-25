using ThrombosisApp.Server.Repositories;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Shared.Dto;

namespace ThrombosisApp.Server.Services;

public class PatientsService
{
    private readonly IPatientRepository _patientRepository;
    public PatientsService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    // private string? updatedPatientFirstName;
    // private string? updatedPatientLastName;
    // private float updatedPatientINR;
    public async Task<Patient?> UpdatePatient(EditPatientDto updatedPatient)
    {
        Patient? originalPatient = _patientRepository.FindPatient(updatedPatient.PatientId);
        if (originalPatient is null) return null;

        originalPatient.FirstName = updatedPatient.FirstName is null ? originalPatient.FirstName : updatedPatient.FirstName;
        originalPatient.LastName = updatedPatient.LastName is null ? originalPatient.LastName : updatedPatient.LastName;
        originalPatient.INR = updatedPatient.INR == 0f ? originalPatient.INR : updatedPatient.INR;

        // Patient newPatient = new() {
        //     PatientId = updatedPatient.PatientId,
        //     FirstName = updatedPatientFirstName,
        //     LastName = updatedPatientLastName,
        //     INR = updatedPatientINR
        // };

        // updatedPatientFirstName = updatedPatient.FirstName is null ? originalPatient.FirstName : updatedPatient.FirstName;
        // updatedPatientLastName = updatedPatient.LastName is null ? originalPatient.LastName : updatedPatient.LastName;
        // updatedPatientINR = updatedPatient.INR == 0f ? originalPatient.INR : updatedPatient.INR;

        // Patient newPatient = new() {
        //     PatientId = updatedPatient.PatientId,
        //     FirstName = updatedPatientFirstName,
        //     LastName = updatedPatientLastName,
        //     INR = updatedPatientINR
        // };

        return (await _patientRepository.UpdateAsync(originalPatient)).Item1;

    }
}