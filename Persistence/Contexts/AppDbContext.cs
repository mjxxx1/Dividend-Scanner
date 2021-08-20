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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=MARIUSZ-PC\\SQLEXPRESS; Database=DividendScannerDB;Trusted_Connection=True; ");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Property Configurations
            modelBuilder.Entity<Company>()
                    .HasKey(x => x.ISIN);

            modelBuilder.Entity<Company>()
                    .Property(x => x.ISIN)
                    .HasMaxLength(12)
                    .IsRequired();

            modelBuilder.Entity<Company>()
                    .Property(x => x.Ticker)
                    .HasMaxLength(3)
                    .IsRequired();

            modelBuilder.Entity<Company>()
                    .Property(x => x.Name)
                    .HasMaxLength(30)
                    .IsRequired();

            modelBuilder.Entity<Company>()
                    .Property(x => x.IsDeleted)
                    .IsRequired();

        }
    }
}
