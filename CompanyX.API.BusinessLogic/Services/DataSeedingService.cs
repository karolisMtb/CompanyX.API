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
            await _dataSeedingRepository.ClearDatabaseAsync();
            await _dataSeedingRepository.SeedInitialDataAsync(_employees, _roles);            
        }

        private void GetRoles()
        {
            _roles.Add(new Role { Name= JobTitle.Ceo} );
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
                    FirstName = "Coral",
                    LastName = "Trout",
                    BirthDate = new DateTime(2015,07,06), 
                    EmploymentDate = new DateTime(2015,07,06), 
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x=>x.Name == JobTitle.Ceo),
                    RoleId = _roles.First(x => x.Name == JobTitle.Ceo).Id
                });

            _employees.Add(
    new Employee
    {
        FirstName = "Coralfdfdsfd",
        LastName = "Troutsfdfsd",
        BirthDate = new DateTime(2015, 07, 06),
        EmploymentDate = new DateTime(2015, 07, 06),
        CurentSalary = 1750.00M,
        Role = _roles.First(x => x.Name == JobTitle.Ceo),
        RoleId = _roles.First(x => x.Name == JobTitle.Ceo).Id
    });



            _employees.Add(
                new Employee
                {
                    FirstName = "Luke",
                    LastName = "Brian",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2015, 07, 06),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Biologist),
                    RoleId = _roles.First(x => x.Name == JobTitle.Biologist).Id
                });

            _employees.Add(
                new Employee
                {
                    FirstName = "Ann",
                    LastName = "Chovey",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2015, 07, 06),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x=>x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Chemist),
                    RoleId = _roles.First(x => x.Name == JobTitle.Chemist).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "Barry",
                    LastName = "Cuda",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2015, 07, 06),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x=>x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Tester),
                    RoleId = _roles.First(x => x.Name == JobTitle.Tester).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "John",
                    LastName = "Dory",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2015, 07, 06),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Supervisor),
                    RoleId = _roles.First(x => x.Name == JobTitle.Supervisor).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "John",
                    LastName = "Deer",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2015, 07, 06),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.ProjectManager),
                    RoleId = _roles.First(x => x.Name == JobTitle.ProjectManager).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "Red",
                    LastName = "Salmon",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2010, 09, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Security),
                    RoleId = _roles.First(x => x.Name == JobTitle.Security).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "Tiger",
                    LastName = "Prawn",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2010, 09, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Chemist),
                    RoleId = _roles.First(x => x.Name == JobTitle.Chemist).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "Mayden",
                    LastName = "Deer",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2010, 09, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Biologist),
                    RoleId = _roles.First(x => x.Name == JobTitle.Biologist).Id
                });

            _employees.Add(
                new Employee{
                    FirstName = "Rock",
                    LastName = "Lobster",
                    BirthDate = new DateTime(2015, 07, 06),
                    EmploymentDate = new DateTime(2010, 09, 15),
                    Boss = _employees.First(x => x.Role.Name == JobTitle.Ceo),
                    BossId = _employees.First(x => x.Role.Name == JobTitle.Ceo).Id,
                    CurentSalary = 1750.00M,
                    Role = _roles.First(x => x.Name == JobTitle.Supervisor),
                    RoleId = _roles.First(x => x.Name == JobTitle.Supervisor).Id
                });
        }
    }
}
