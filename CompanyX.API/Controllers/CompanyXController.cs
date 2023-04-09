using CompanyX.API.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyXController : ControllerBase
    {
        [HttpGet]
        [Route("Employee/{id}")]
        public async Task<IActionResult> Employee()
        {
            return Ok(ModelState);
        }

        [HttpGet]
        [Route("Employees/BirthDate")]
        public async Task<IActionResult> BirthDate(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Employees")]
        public async Task<IActionResult> Employees()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Employees/Boss/{id}")]
        public async Task<IActionResult> BossesEmployees(Guid bossId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Employee/Info")]
        public async Task<IActionResult> EmployeeInfo(string role)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Employee")]
        public async Task<IActionResult> Employee(Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Employee")]
        public async Task<IActionResult> EmployeeUpdate(Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("Employee/Salary")]
        public async Task<IActionResult> Salary(decimal newSalary)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("Employee/Delete")]
        public async Task<IActionResult> Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
