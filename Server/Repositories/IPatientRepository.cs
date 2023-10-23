using ThrombosisApp.Server.Models;

namespace ThrombosisApp.Server.Repositories;

public interface IPatientRepository
{
    // Task<Patient?>
    Task<Patient?> CreateAsync(Patient newPatient);
    Task<Patient?> UpdateAsync(Patient updatedPatient);
    Task<IEnumerable<Patient>> RetrieveAllAsync();
    Task<bool?> DeleteAsync(int patientId);
}