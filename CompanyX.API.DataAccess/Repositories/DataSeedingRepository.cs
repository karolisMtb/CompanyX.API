using CompanyX.API.DataAccess.DatabaseContext;
using CompanyX.API.DataAccess.Entities;
using CompanyX.API.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;

namespace CompanyX.API.DataAccess.Repositories
{
    public class DataSeedingRepository : IDataSeedingRepository
    {
        protected readonly ILogger<IEmployeeRepository> _logger;
        protected readonly CompanyXDbContext _companyXDbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public DataSeedingRepository(CompanyXDbContext companyXDbContext, ILogger<IEmployeeRepository> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _companyXDbContext = companyXDbContext;
            _employeeRepository = employeeRepository;
        }

        public async Task ClearDatabaseAsync()
        {
            _companyXDbContext.Employees.RemoveRange(_companyXDbContext.Employees);
            _companyXDbContext.HomeAddresses.RemoveRange(_companyXDbContext.HomeAddresses);
            _companyXDbContext.Roles.RemoveRange(_companyXDbContext.Roles);
            await SaveChangesAsync();
        }

        public async Task SeedInitialDataAsync(List<Employee> employees, List<Role> roles)
        {
            await ClearDatabaseAsync();
            await _companyXDbContext.Roles.AddRangeAsync(roles);

            await _employeeRepository.AddEmployees(employees);

            await _companyXDbContext.Employees.AddRangeAsync(employees);
            await SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _companyXDbContext.SaveChangesAsync();
        }
    }
}
