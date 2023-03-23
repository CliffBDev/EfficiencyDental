
using EfficiencyDental.API.Middlewear;
using EfficiencyDental.Application.Business.Tenant;
using EfficiencyDental.Infrastructure.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfraServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<MultitenantMiddlewear>();
var app = builder.Build();

//Multitenancy is currently being config driven, but in the long run it is 
//certainly more scalable to have it be database driven. 
//But for now this will work just fine. 

var connectionStringNames = builder.Configuration.GetSection("ConnectionStringNames").Get<string[]>();

foreach (var tenant in connectionStringNames)
{
    using (var scope = app.Services.CreateScope())
    {
        var tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
        tenantService.SetTenant(tenant);
        var initalizer = scope.ServiceProvider.GetRequiredService<ApplicationContextInitializer>();
        await initalizer.MigrateAsync();
    }    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();