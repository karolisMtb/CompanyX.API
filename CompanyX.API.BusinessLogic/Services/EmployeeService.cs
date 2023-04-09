using CompanyX.API.BusinessLogic.Interfaces;
using CompanyX.API.DataAccess.Entities;
using CompanyX.API.DataAccess.Interfaces;

namespace CompanyX.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task AddNewEmployeeAsync(Employee employee)
        {
            Employee newEmployee = new Employee();
            newEmployee = employee;
        }

        public Task DeleteEmployeeAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<int, decimal>> GetEmployeeSalaryAverageAsync(string role)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployeesByBossIdAsync(Guid bossId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployeesByNameAndBirthDateAsync(string name, DateTime birthdateFrom, DateTime birthDateTo)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeSalary(Guid employeeId, decimal salary)
        {
            throw new NotImplementedException();
        }
    }
}
