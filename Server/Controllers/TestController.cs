using Microsoft.AspNetCore.Mvc;

namespace ThrombosisApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    // host/controllername
    [HttpGet]
    public string TestGet()
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
    [HttpGet("{id:int}")]
    public string TestWithAddedRouting(int id)
    {
        return $"Hit the third endpoint with numnber {id}";
    }
}