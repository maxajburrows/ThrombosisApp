using ThrombosisApp.Server.Models;

namespace ThrombosisApp.Server.Repositories;

public interface IPatientRepository
{
    // Task<Patient?>
    Task<IEnumerable<Patient>> RetrieveAllAsync();
    Task<bool?> DeleteAsync(string patientId)
}