using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Reflection;

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
        modelBuilder.Entity<City>(builder =>
        {
            builder.ToTable("city")
            .HasKey(c => c.Id);

            builder.HasOne(c => c.Country);

            builder.Property(c => c.Id)
                .HasColumnName("city_id");

            builder.Property(c => c.Name)
                .HasColumnName("city");

            builder.Property(c => c.CountryId)
                .HasColumnName("country_id");

            builder.Property(c => c.LastUpdate)
                .HasColumnName("last_update");
        });

        modelBuilder.Entity<Country>(builder => {
            builder.ToTable("country")
            .HasKey(c => c.Id);

            builder.HasMany(c => c.Cities);

            builder.Property(c => c.Id)
                .HasColumnName("country_id");

            builder.Property(c => c.Name)
                .HasColumnName("country");

            builder.Property(c => c.LastUpdate)
                .HasColumnName("last_update");
        });
    }
}

