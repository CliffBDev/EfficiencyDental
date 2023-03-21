using Microsoft.EntityFrameworkCore;

namespace EfficiencyDental.Infrastructure.Persistence.Contexts;

public class ApplicationContextInitializer
{
    private readonly IApplicationDbContext _context;

    public ApplicationContextInitializer(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task MigrateAsync()
    {
        await _context.DataBase.MigrateAsync(); 
    }
}