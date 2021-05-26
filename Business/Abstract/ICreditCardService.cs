using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> GetCardByNumber(string card);
    }
}
