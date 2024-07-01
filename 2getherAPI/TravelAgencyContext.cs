using _2getherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace _2getherAPI
{
    public class TravelAgencyContext : DbContext
    {
        public DbSet<Reise> Reises { get; set; }
        public DbSet<Reiseziel> Reiseziels { get; set; }
        public DbSet<Teilnehmer> Teilnehmers { get; set; }

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
                .HasKey(rz => new { rz.r_id, rz.rz_id });

            modelBuilder.Entity<Reiseziel>()
                .HasOne(rz => rz.Reise)
                .WithMany(r => r.Reiseziels)
                .HasForeignKey(rz => rz.r_id);

            modelBuilder.Entity<Teilnehmer>()
                .ToTable("teilnehmer")
                .HasKey(t => t.t_username);

            modelBuilder.Entity<Reise>()
                .HasMany(r => r.Teilnehmers)
                .WithMany(t => t.Reises)
                .UsingEntity<Dictionary<string, object>>(
                    "reise_teilnehmer",
                    r => r.HasOne<Teilnehmer>().WithMany().HasForeignKey("t_username"),
                    t => t.HasOne<Reise>().WithMany().HasForeignKey("r_id"));
        }
    }
}