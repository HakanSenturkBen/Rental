using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerFindexService
    {
        IDataResult<CustomerFindex> GetFindexByCustomerId(int customerId);
        IResult Add(CustomerFindex findex);
    }
}
