using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Data;

namespace ThrombosisApp.Server.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly PatientDB _context;
    public PatientRepository(PatientDB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> RetrieveAllAsync()
    {   
        return await _context.Patients.ToListAsync();
    }
}