using CompanyX.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace CompanyX.API.DataAccess.DatabaseContext
{
    public class CompanyXDbContext : DbContext
    {
        public CompanyXDbContext(DbContextOptions<CompanyXDbContext> options) : base(options) // kas yra DbContextOptions??
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HomeAddress> HomeAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) // kas yra protected??
        {

        }
    }
}
