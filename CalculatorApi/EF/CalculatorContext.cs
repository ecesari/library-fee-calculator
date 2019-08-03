using System.IO.Compression;
using CalculatorApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalculatorApi.EF
{
    public class CalculatorContext:DbContext
    {
        public CalculatorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        //public DbSet<DayOfWeek> WeekEnds { get; set; }
        //public DbSet<CountryWeekend> CountryWeekends { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(p => p.Holidays)
                .WithOne(z=>z.Country);

        }
    }


}
