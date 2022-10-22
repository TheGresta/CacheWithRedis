using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Context;

public class BaseDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

