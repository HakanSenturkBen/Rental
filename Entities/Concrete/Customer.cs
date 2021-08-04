using Core.Entities;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }
        public int CreditCardId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string CitizenShipNumber { get; set; }
    }

}
