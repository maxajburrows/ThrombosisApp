using ThrombosisApp.Server.Models;
using ThrombosisApp.Shared.Dto;

namespace ThrombosisApp.Server.Repositories;

public interface IPatientRepository
{
    // Task<Patient?>
    Task<Patient?> CreateAsync(NewPatientDto newPatient);
    Task<Patient?> UpdateAsync(Patient updatedPatient);
    Task<IEnumerable<Patient>> RetrieveAllAsync();
    Task<bool?> DeleteAsync(int patientId);
}