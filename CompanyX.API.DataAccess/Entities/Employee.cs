using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyX.API.DataAccess.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        //[Compare(nameof(FirstName), ErrorMessage = "Names should be different")] // parasyti custom comparer
        public string LastName { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        public DateTime EmploymentDate { get; set; }
        public Employee? Boss { get; set; }
        public Guid? BossId { get; set; }
        // address is one to many relationship
        [Required]
        public decimal CurentSalary { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public Guid? RoleId { get; set; }

    }
}
