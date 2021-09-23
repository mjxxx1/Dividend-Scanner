using DividendScanner.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DividendScanner.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Company properties configuration
            modelBuilder.Entity<Company>()
                    .HasKey(x => x.ID);

            modelBuilder.Entity<Company>()
                    .Property(x => x.ISIN)
                    .HasMaxLength(12)
                    .IsRequired();

            modelBuilder.Entity<Company>()
                    .Property(x => x.Ticker)
                    .HasMaxLength(4)
                    .IsRequired();

            modelBuilder.Entity<Company>()
                    .Property(x => x.Name)
                    .HasMaxLength(30)
                    .IsRequired();

            modelBuilder.Entity<Company>()
                    .Property(x => x.IsDeleted)
                    .HasDefaultValue(false);


            //Sector properties configuration
            modelBuilder.Entity<Sector>()
                    .HasKey(x => x.ID);

            modelBuilder.Entity<Sector>()
                    .Property(x => x.Name)
                    .IsRequired();

            modelBuilder.Entity<Sector>()
                    .Property(x => x.IsDeleted)
                    .HasDefaultValue(false);
        }
    }
}
