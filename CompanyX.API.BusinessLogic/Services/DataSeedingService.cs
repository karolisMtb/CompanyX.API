using CompanyX.API.BusinessLogic.Interfaces;
using CompanyX.API.DataAccess.Entities;
using CompanyX.API.DataAccess.Enums;
using CompanyX.API.DataAccess.Interfaces;

namespace CompanyX.API.BusinessLogic.Services
{
    public class DataSeedingService : IDataSeedingService
    {
        private readonly List<Role> _roles = new List<Role>();
        private List<Employee> _employees = new List<Employee>();
        private readonly IDataSeedingRepository _dataSeedingRepository;
        public DataSeedingService(IDataSeedingRepository dataSeedingRepository)
        {
            _dataSeedingRepository = dataSeedingRepository;
            GetRoles();
            GetEmployees();
        }

        public async Task SeedInitialDataAsync()
        {
            await _dataSeedingRepository.SeedInitialDataAsync(_employees, _roles);            
        }

        private void GetRoles()
        {
            _roles.Add(new Role { Name = JobTitle.Ceo });
            _roles.Add(new Role { Name = JobTitle.Biologist });
            _roles.Add(new Role { Name = JobTitle.Tester });
            _roles.Add(new Role { Name = JobTitle.ProjectManager });
            _roles.Add(new Role { Name = JobTitle.Supervisor });
            _roles.Add(new Role { Name = JobTitle.Security });
            _roles.Add(new Role { Name = JobTitle.Chemist });
        }

        private void GetEmployees()
        {
            _employees.Add(
                new Employee
                {
                    FirstName = "Bruce",
                    LastName = "Willis",
                    BirthDate = new DateTime(1987,03,12), 
                    EmploymentDate = new DateTime(2000,01,02), 
                    CurentSalary = 2680.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Ceo),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Luke",
                    LastName = "Brian",
                    BirthDate = new DateTime(1968, 11, 25),
                    EmploymentDate = new DateTime(2002, 01, 02),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 2310.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Biologist),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Ann",
                    LastName = "Chovey",
                    BirthDate = new DateTime(1991, 06, 06),
                    EmploymentDate = new DateTime(2010, 10, 09),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 1860.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Biologist),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Barry",
                    LastName = "Cuda",
                    BirthDate = new DateTime(1995, 04, 25),
                    EmploymentDate = new DateTime(2013, 05, 01),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 2100.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Tester),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "John",
                    LastName = "Dory",
                    BirthDate = new DateTime(1980, 09, 03),
                    EmploymentDate = new DateTime(2014, 03, 01),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 1980.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Supervisor),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "John",
                    LastName = "Deer",
                    BirthDate = new DateTime(1965, 12, 24),
                    EmploymentDate = new DateTime(2015, 02, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 1280.00M,
                    Role = _roles.First(x => x.Name == JobTitle.ProjectManager),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Red",
                    LastName = "Salmon",
                    BirthDate = new DateTime(1978, 06, 19),
                    EmploymentDate = new DateTime(2012, 04, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 1820.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Security),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Tiger",
                    LastName = "Prawn",
                    BirthDate = new DateTime(1966, 08, 20),
                    EmploymentDate = new DateTime(2010, 09, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 1650.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Chemist),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Mayden",
                    LastName = "Deer",
                    BirthDate = new DateTime(2000, 05, 25),
                    EmploymentDate = new DateTime(2020, 07, 01),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 2510.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Biologist),
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Rock",
                    LastName = "Lobster",
                    BirthDate = new DateTime(1999, 03, 13),
                    EmploymentDate = new DateTime(2018, 11, 01),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    CurentSalary = 975.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Supervisor),
                });
        }
    }
}
