using Microsoft.EntityFrameworkCore;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Data;
using ThrombosisApp.Server.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ThrombosisApp.Shared.Dto;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
    public async Task<(Patient?, bool)> CreateAsync(NewPatientDto newPatient)
    {
        EntityEntry<Patient> added = await _context.Patients.AddAsync(Converters.NewPatientDtoToPatient(newPatient));
        int affected = await _context.SaveChangesAsync();
        return (added.Entity, affected == 1);
    }

    public async Task<(Patient?, bool)> UpdateAsync(Patient updatedPatient)
    {
        EntityEntry<Patient> updated = _context.Patients.Update(updatedPatient);
        int affected = await _context.SaveChangesAsync();
        return (updated.Entity, affected == 1);
    }

    public async Task<bool> DeleteAsync(int patientId)
    {  
        Patient? patient = _context.Patients.Find(patientId);

        if (patient is null) return false;
        _context.Patients.Remove(patient);

        int affected = await _context.SaveChangesAsync();
        return affected == 1;
    }

    public Patient? FindPatient(int patientId)
    {
        return _context.Patients.Find(patientId);
    }
}