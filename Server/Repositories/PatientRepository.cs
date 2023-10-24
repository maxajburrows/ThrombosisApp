using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Data;
using ThrombosisApp.Server.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ThrombosisApp.Shared.Dto;

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
        IEnumerable<Patient> patientList = await _context.Patients.ToListAsync();
        return await _context.Patients.ToListAsync();
    }
    public async Task<Patient?> CreateAsync(NewPatientDto newPatient)
    {
        EntityEntry<Patient> added = await _context.Patients.AddAsync(Converters.NewPatientDtoToPatient(newPatient));
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<Patient?> UpdateAsync(Patient updatedPatient)
    {
        EntityEntry<Patient> updated = _context.Patients.Update(updatedPatient);
        await _context.SaveChangesAsync();
        return updated.Entity;
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