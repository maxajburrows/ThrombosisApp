using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThrombosisApp.Server.Repositories;
using ThrombosisApp.Server.Models;
using ThrombosisApp.Server.Services;
using ThrombosisApp.Shared.Dto;

namespace ThrombosisApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    private readonly PatientsService _patientsService;

    public PatientsController(IPatientRepository patientRepository, PatientsService patientsService)
    {
        _patientRepository = patientRepository;
        _patientsService = patientsService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<PatientResponseDto>))]
    public async Task<ActionResult<List<PatientResponseDto>>> GetAllPatients()
    {
        List<Patient> patientEntities = await _patientRepository.RetrieveAllAsync();
        return Ok(patientEntities.Select(Converters.ToPatientResponseDto));
    }

    [HttpGet("{patientId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<PatientResponseDto>))]
    public ActionResult<PatientResponseDto> GetDoseInfo(int patientId)
    {
        Patient? patient =  _patientsService.GetPatientById(patientId);
        return Ok(Converters.ToPatientResponseDto(patient));
    }

    [HttpDelete("{patientId}")]
    public async Task<ActionResult<bool?>> DeletePatient(int patientId)
    {
        await _patientRepository.DeleteAsync(patientId);
        return NoContent();
    }

    [HttpPatch("{patientId}")]
    public async Task<ActionResult<Patient>> UpdatePatient(int patientId, [FromBody] EditPatientDto updatedPatient)
    {
        return Ok(await _patientsService.UpdatePatient(updatedPatient));
    }

    [HttpPost]
    public async Task<ActionResult<PatientResponseDto?>> AddPatient([FromBody] NewPatientDto newPatient)
    {
        return Created("You can't access this resource yet", Converters.ToPatientResponseDto((await _patientRepository.CreateAsync(newPatient)).Item1));
    }
}