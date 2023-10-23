using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    public async Task<Patient?> CreateAsync(Patient newPatient)
    {
        EntityEntry<Patient> added = await _context.Patients.AddAsync(newPatient);
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<Patient?> UpdateAsync(Patient updatedPatient)
    {
        _context.Patients.Update(updatedPatient);
        await _context.SaveChangesAsync();
        Patient? editedPatient = _context.Patients.Find(updatedPatient.PatientId);
        return editedPatient;
    }

    public async Task<bool?> DeleteAsync(int patientId)
    {  
        Patient? patient = _context.Patients.Find(patientId);

        if (patient is null) return false;
        _context.Patients.Remove(patient);

        int affected = await _context.SaveChangesAsync();
        return affected == 1;
    }
}