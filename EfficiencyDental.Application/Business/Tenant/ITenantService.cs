using Microsoft.Extensions.Configuration;

namespace EfficiencyDental.Application.Business.Tenant;

public interface ITenantService
{
    public void SetTenant(string tenant);
    public string? GetTenantConnectionString();
}

public class TenantService : ITenantService
{
    private string _tenant;
    private readonly IConfiguration _configuration;
    public TenantService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string? GetTenantConnectionString()
    {
        return _configuration[$"ConnectionStrings:{_tenant}"];
    }

    public void SetTenant(string tenant)
    {
        _tenant = tenant;
    }
}