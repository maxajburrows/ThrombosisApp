using Microsoft.AspNetCore.Mvc;

namespace ThrombosisApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    // host/Patients
    [HttpGet]
    public string GetAllPatients()
    {
        return "Hit the first endpoint";
    }
    // host/controllername/routed
    [HttpGet("routed")]
    public string TestWithAddedRouting()
    {
        return "Hit the second endpoint";
    }
    // host/controllername/[id]
    [HttpDelete("{id:int}")]
    public string TestWithAddedRouting(int id)
    {
        return $"Hit the third endpoint with numnber {id}";
    }
}