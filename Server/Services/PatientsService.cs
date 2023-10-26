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
    public async Task<List<PatientResponseDto>> GetAllPatients()
    {
        List<Patient> patientEntities = await _patientRepository.RetrieveAllAsync();
        return patientEntities.Select(Converters.ToPatientResponseDto).ToList();
    }
    public async Task<PatientResponseDto?> UpdatePatient(EditPatientDto updatedPatient)
    {
        Patient? originalPatient = _patientRepository.GetPatientAndDosage(updatedPatient.PatientId);
        if (originalPatient is null) return null;

        originalPatient.FirstName = updatedPatient.FirstName is null ? originalPatient.FirstName : updatedPatient.FirstName;
        originalPatient.LastName = updatedPatient.LastName is null ? originalPatient.LastName : updatedPatient.LastName;
        //originalPatient.INR = updatedPatient.INR == 0f ? originalPatient.INR : updatedPatient.INR;
        if (updatedPatient.INR != 0f)
        {
            originalPatient.INR = updatedPatient.INR;
            for (int i = 0; i < 30; i++)
            {
                originalPatient.DoseDescriptions[i].Dose = Converters.CalculateDose(updatedPatient.INR, i);
            }
        }
        return Converters.ToPatientResponseDto((await _patientRepository.UpdateAsync(originalPatient)).Item1);
    }
    public async Task<PatientResponseDto?> AddPatient(NewPatientDto newPatient)
    {
        Patient patientToAdd = Converters.NewPatientDtoToPatient(newPatient);
        return Converters.ToPatientResponseDto((await _patientRepository.CreateAsync(patientToAdd)).Item1);
    }
    
    public Patient? GetPatientById(int patientId)
    {
        return _patientRepository.GetPatientAndDosage(patientId);
    }

    public async Task<bool?> DeletePatient(int patientId)
    {
        return await _patientRepository.DeleteAsync(patientId);
    }

    public async Task<List<DoctorResponseDto>> GetAllDoctors()
    {
        List<Doctor> doctors = await _patientRepository.GetDoctorsAsync();
        return doctors.Select(Converters.ToDoctorResponseDto).ToList();
    }
}