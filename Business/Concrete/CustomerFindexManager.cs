using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerFindexManager : ICustomerFindexService
    {
        ICustomerFindexDal findexDal;
        public CustomerFindexManager(ICustomerFindexDal _findexDal)
        {
            findexDal = _findexDal;
        }

        public IResult Add(CustomerFindex findex)
        {
            findexDal.Add(findex);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<CustomerFindex> GetFindexByCustomerId(int customerId)
        {
            var result = new SuccessDataResult<CustomerFindex>(findexDal.Get(x => x.CustomerId == customerId));
            if (result.Data != null)
            {
                return result;
            }
            return new ErrorDataResult<CustomerFindex>(findexDal.Get(x => x.CustomerId == customerId));
        }
    }
}
