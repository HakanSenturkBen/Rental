using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDto : IDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string CitizenShipNumber { get; set; }
        public string CompanyName { get; set; }
        public string TaxOfficeName { get; set; }
        public string TaxNumber { get; set; }
        public string CoPhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
