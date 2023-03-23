
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
        if (context.Request.Query.TryGetValue("tenant", out var values))
        {
            _tenantService.SetTenant(values.First());
            await next(context);
        }

        throw new Exception("Tenant must be passed in query");
    }
}