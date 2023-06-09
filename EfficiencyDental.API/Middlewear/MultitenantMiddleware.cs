
using EfficiencyDental.Application.Business.Tenant;

namespace EfficiencyDental.API.Middleware;

public class MultitenantMiddleware : IMiddleware
{
    private ITenantService _tenantService;
    public MultitenantMiddleware(ITenantService tenantService)
    { 
        _tenantService = tenantService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Headers.TryGetValue("tenant", out var values))
        {
            _tenantService.SetTenant(values.First());
            await next(context);
        }
        else
        {
            throw new Exception("Tenant must be passed in headers");
        }
    }
}