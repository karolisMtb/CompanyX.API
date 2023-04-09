using CompanyX.API.DataAccess.Entities;

namespace CompanyX.API.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Guid> GetRoleIdByName(string role);
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> GetEmployeeByFilter(string name, DateTime dateOfBirthFrom, DateTime dateOfBirthTo);
        Task<IEnumerable<Employee>> GetEmployeesByBossId(Guid id);
        Task<Dictionary<int, decimal>> GetEmployeeStatistics(string role);
        Task UpdateSalary(Guid employeeId, decimal salary);
        Task DeleteEmployee(Guid employeeId);
        Task SaveChangesAsync();
        Task AddEmployees(List<Employee> employees);
        Task AddEmployee(Employee employee);
    }
}
