using ThrombosisApp.Server.Models;
using ThrombosisApp.Shared.Dto;

namespace ThrombosisApp.Server.Repositories;

public interface IPatientRepository
{
    // Task<Patient?>
    Task<(Patient?, bool)> CreateAsync(NewPatientDto newPatient);
    Task<(Patient?, bool)> UpdateAsync(Patient updatedPatient);
    Task<List<Patient>> RetrieveAllAsync();
    Task<bool> DeleteAsync(int patientId);
    Patient? FindPatient(int patientId);
    Patient? GetPatientAndDosage(int patientId);
    Task<List<Doctor>> GetDoctorsAsync();
}