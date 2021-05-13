using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal addressDal;
        public AddressManager(IAddressDal _addressDal)
        {
            addressDal = _addressDal;
        }

        public void Add(Address address)
        {
            addressDal.Add(address);
        }

        public void Delete(Address address)
        {
            addressDal.Delete(address);
        }

        public void Update(Address address)
        {
            addressDal.Update(address);
        }
    }
}
