using CompanyX.API.DataAccess.Entities;

namespace CompanyX.API.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        Task<IEnumerable<Employee>> GetEmployeesByNameAndBirthDateAsync(string name, DateTime birthdateFrom, DateTime birthDateTo);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> GetEmployeesByBossIdAsync(Guid bossId);
        Task<Dictionary<int, decimal>> GetEmployeeSalaryAverageAsync(string role);
        Task AddNewEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task UpdateEmployeeSalary(Guid employeeId, decimal salary);
        Task DeleteEmployeeAsync(Guid employeeId);
    }
}
