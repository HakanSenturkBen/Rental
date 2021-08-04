using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Address address)
        {
            addressDal.Add(address);
            return new SuccessResult(address.Id.ToString());
        }

        public IResult Update(Address address)
        {
            addressDal.Update(address);
            return new SuccessResult(Messages.Updated);
        }
    }
}
