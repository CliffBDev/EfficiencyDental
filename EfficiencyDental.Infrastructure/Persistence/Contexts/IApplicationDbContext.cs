using EfficiencyDental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfficiencyDental.Infrastructure.Persistence.Contexts;

public interface IApplicationDbContext
{
    public DbSet<Practice> Practices { get; set; }
    public DatabaseFacade DataBase { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}