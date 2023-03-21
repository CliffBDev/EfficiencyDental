using EfficiencyDental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfficiencyDental.Infrastructure.Persistence.Contexts;

public class ApplicationContext : DbContext, IApplicationDbContext
{

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    public DbSet<Practice> Practices { get; set; } 
    public DatabaseFacade DataBase
    {
        get
        {
            return base.Database;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}