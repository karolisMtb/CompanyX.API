using CompanyX.API.DataAccess.Entities;
using FluentValidation;

namespace CompanyX.API.DataAccess.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEqual(x => x.LastName).WithMessage("First name cannot be equal to last name.");
            RuleFor(x => x.BirthDate).Must(ValidAge).WithMessage("Employee must be at least 18 years old and not older than 70.");
            RuleFor(x => x.EmploymentDate).GreaterThanOrEqualTo(DateTime.Parse("2000,01,01")).WithMessage("Employment date cannot be earlier than 2000-01-01");
            RuleFor(x => x.EmploymentDate).LessThan(DateTime.UtcNow).WithMessage("Employment date cannot be future date");
            RuleFor(x => x.CurentSalary).GreaterThanOrEqualTo(0).WithMessage("Salary must be non-negative");
        }

        private bool ValidAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;

            if(age < 18 || age >= 70)
            {
                return false;
            }

            return true;
        }
    }
}
