using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAddressService
    {
        void Add(Address address);
        void Update(Address address);
        void Delete(Address address);
    }
}
