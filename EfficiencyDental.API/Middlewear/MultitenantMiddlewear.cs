
using EfficiencyDental.Application.Business.Tenant;

namespace EfficiencyDental.API.Middlewear;

public class MultitenantMiddlewear : IMiddleware
{
    private ITenantService _tenantService;
    public MultitenantMiddlewear(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Query.TryGetValue("tenant", out var values))
        {
            _tenantService.SetTenant(values.First());
        }

        await next(context);
    }
}