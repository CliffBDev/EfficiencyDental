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
    public DbSet<Office> Offices { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

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