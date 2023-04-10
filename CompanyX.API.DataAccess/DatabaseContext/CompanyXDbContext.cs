using CompanyX.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CompanyX.API.DataAccess.Enums;

namespace CompanyX.API.DataAccess.DatabaseContext
{
    public class CompanyXDbContext : DbContext
    {
        public CompanyXDbContext(DbContextOptions<CompanyXDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HomeAddress> HomeAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Role>()
            .Property(x => x.Name)
            .HasConversion(new EnumToStringConverter<JobTitle>());            
        }
    }
}
