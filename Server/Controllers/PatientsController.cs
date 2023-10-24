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
    public PatientsController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    // host/controllername
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Patient>))]
    public async Task<ActionResult<IEnumerable<PatientResponseDto>>> GetAllPatients()
    {
        IEnumerable<Patient> patientEntities = await _patientRepository.RetrieveAllAsync();
        return Ok(patientEntities.Select(Converters.ToPatientResponseDto));
    }

    // host/controllername/routed
    [HttpDelete("{patientId}")]
    public async Task<ActionResult<bool?>> DeletePatient(int patientId)
    {
        await _patientRepository.DeleteAsync(patientId);
        return NoContent();
        //Deal with failure
    }
    // host/controllername/[id]
    [HttpPatch("{patientId}")]
    public async Task<ActionResult<Patient>> UpdatePatient(int patientId, [FromBody] Patient updatedPatient)
    {
        return Ok(await _patientRepository.UpdateAsync(updatedPatient));
    }

    [HttpPost]
    public async Task<ActionResult<Patient?>> AddPatient([FromBody] NewPatientDto newPatient)
    {
        return Created("You can't access this resource yet", await _patientRepository.CreateAsync(newPatient));
    }
}