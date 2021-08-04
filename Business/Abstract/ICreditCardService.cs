using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<CreditCard> GetCardByNumber(string card);
        IResult Add(CreditCard card);
        IResult Update(CreditCard card);
        IDataResult<CreditCard> GetCardByCustomerId(int customerId);
        IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);
    }
}
