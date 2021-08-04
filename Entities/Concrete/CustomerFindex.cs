using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerFindex : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FindexPoint { get; set; }
    }

}
