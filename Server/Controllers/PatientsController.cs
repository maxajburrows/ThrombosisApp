using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThrombosisApp.Server.Repositories;
using ThrombosisApp.Server.Models;


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
    public async Task<IEnumerable<Patient>> GetAllPatients()
    {
        return await _patientRepository.RetrieveAllAsync();
    }


    // host/controllername/routed
    [HttpDelete("{patientId}")]
    public async Task<bool?> DeletePatient(int patientId)
    {
        return await _patientRepository.DeleteAsync(patientId);
    }
    // host/controllername/[id]
    [HttpGet("{id:int}")]
    public string TestWithAddedRouting(int id)
    {
        return $"Hit the third endpoint with numnber {id}";
    }
}