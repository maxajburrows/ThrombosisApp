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
    public async Task<Patient?> UpdatePatient(EditPatientDto updatedPatient)
    {
        Patient? originalPatient = _patientRepository.FindPatient(updatedPatient.PatientId);
        if (originalPatient is null) return null;

        originalPatient.FirstName = updatedPatient.FirstName is null ? originalPatient.FirstName : updatedPatient.FirstName;
        originalPatient.LastName = updatedPatient.LastName is null ? originalPatient.LastName : updatedPatient.LastName;
        originalPatient.INR = updatedPatient.INR == 0f ? originalPatient.INR : updatedPatient.INR;

        return (await _patientRepository.UpdateAsync(originalPatient)).Item1;
    }
}