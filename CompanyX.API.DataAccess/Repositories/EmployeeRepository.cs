using CompanyX.API.DataAccess.DatabaseContext;
using CompanyX.API.DataAccess.Entities;
using CompanyX.API.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CompanyX.API.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyX.API.DataAccess.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        protected readonly CompanyXDbContext _companyXDbContext;
        protected readonly ILogger<IEmployeeRepository> _logger; 

        public EmployeeRepository(CompanyXDbContext companyXDbContext, ILogger<IEmployeeRepository> logger) : base(companyXDbContext)
        {
            _logger = logger;
            _companyXDbContext = companyXDbContext;
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            _companyXDbContext.Employees.Remove(await GetEmployeeById(employeeId));
        }

        public async Task AddEmployees(List<Employee> employees)
        {
            if(employees.Where(x => x.Role.Name == JobTitle.Ceo).Count() > 1)
            {
                throw new ValidationException("Only one person with CEO role per database allowed");
            }

            if(employees.Any(x => x.Role.Name == JobTitle.Ceo))
            {
                if (await _companyXDbContext.Employees.AnyAsync() && await _companyXDbContext.Employees.AnyAsync(x => x.Role.Name == JobTitle.Ceo))
                {
                    throw new ValidationException("Only one person with CEO role per database allowed");
                }
            }

            await _companyXDbContext.Employees.AddRangeAsync(employees);
            await SaveChangesAsync();
        }

        public async Task AddEmployee(Employee employee)
        {
            if (employee.Role.Name == JobTitle.Ceo)
            {
                if (await _companyXDbContext.Employees.AnyAsync() && await _companyXDbContext.Employees.AnyAsync(x => x.Role.Name == JobTitle.Ceo))
                {
                    throw new ValidationException("Only one person with CEO role per database allowed");
                }
            }

            await _companyXDbContext.Employees.AddAsync(employee);
            await SaveChangesAsync();

        }

        public async Task<IEnumerable<Employee>> GetEmployeeByFilter(string name, DateTime dateOfBirthFrom, DateTime dateOfBirthTo)
        {
            return await _companyXDbContext.Employees.Where(x => x.FirstName == name).Where(x => x.BirthDate > dateOfBirthFrom && x.BirthDate < dateOfBirthTo).ToListAsync();
        }

        public async  Task<Employee> GetEmployeeById(Guid id)
        {
            return await _companyXDbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByBossId(Guid id)
        {
            return await _companyXDbContext.Employees.Where(x => x.BossId == id).ToListAsync();
        }

        public async Task<Dictionary<int, decimal>> GetEmployeeStatistics(string role)
        {
            Dictionary<int, decimal> statistics = new Dictionary<int, decimal>();
            //int employeeCount = await _companyXDbContext.Employees.Where(x => x.Role.Name == role).CountAsync();
            //decimal averageSalary = _companyXDbContext.Employees.Where(x => x.Role.Name == role).Select(x => x.CurentSalary).ToList().Sum() / employeeCount;
            //statistics.TryAdd(employeeCount, averageSalary);
            return statistics;
        }

        public async Task UpdateSalary(Guid employeeId, decimal salary)
        {
            Employee employee = await GetEmployeeById(employeeId);
            employee.CurentSalary = salary;
            _companyXDbContext.Employees.Update(employee);
        }

        public async Task SaveChangesAsync()
        {
            await _companyXDbContext.SaveChangesAsync();
        }

        Task<Employee> IEmployeeRepository.GetEmployeeByFilter(string name, DateTime dateOfBirthFrom, DateTime dateOfBirthTo)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetRoleIdByName(string role)
        {
            //if(!_companyXDbContext.Roles.Where(x => x.Name == role).Any())
            //{
            //    _logger.LogError("Entry could not be found");
            //}

            //return  _companyXDbContext.Roles.FirstOrDefault(x => x.Name == role).Id;
            return Guid.NewGuid();
        }

    }
}
