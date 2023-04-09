using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyX.API.DataAccess.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }

        public Employee? Boss { get; set; }

        [Required]
        public decimal CurentSalary { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
