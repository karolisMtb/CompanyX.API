using System.ComponentModel.DataAnnotations;

namespace CompanyX.API.DataAccess.Entities
{
    public class HomeAddress
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = Guid.NewGuid(); }
        }

        [Required]
        public string StreetName { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string? AdditionalAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        public Guid EmployeeId { get; set; }

    }
}
