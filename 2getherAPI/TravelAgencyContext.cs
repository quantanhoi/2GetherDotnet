using _2getherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _2getherAPI;

public class TravelAgencyContext : DbContext
{
    public DbSet<Reise> Reises { get; set; }
    public DbSet<Reiseziel> Reiseziels { get; set; }

    public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reise>()
            .ToTable("reise")
            .HasKey(r => r.r_id);
        modelBuilder.Entity<Reiseziel>()
            .ToTable("reiseziel")
            .HasKey((rz => rz.rz_id));
    }
}