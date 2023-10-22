using ThrombosisApp.Server.Models;

namespace ThrombosisApp.Server.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> RetrieveAllAsync();
}