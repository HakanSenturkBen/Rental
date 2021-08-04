using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string ValidationDate { get; set; }
        public string Cvv { get; set; }
        public int Limit { get; set; }
        public string CardHolderName { get; set; }
    }

}
