using Core.Entities;

namespace Entities.Concrete
{
    public class BankPayment : IEntity
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public int RentalId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string CreditCardNumber { get; set; }
        public int TransactionAmount { get; set; }
    }

}
