using System.Runtime.CompilerServices;
using EfficiencyDental.Application.Business.Tenant;
using Microsoft.AspNetCore.Mvc;

namespace EfficiencyDental.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly ITenantService _tenantService;

    public StatusController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var cs = _tenantService.GetTenantConnectionString();
        return Ok(cs);
    }
}