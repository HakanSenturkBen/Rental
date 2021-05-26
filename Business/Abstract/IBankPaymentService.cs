using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBankPaymentService
    {
        IDataResult<List<BankPayment>> GetAll();
        IDataResult<BankPayment> GetPaymentById(int paymentId);
        IResult Add(BankPayment payment);
        IResult Update(BankPayment payment);
        IResult Delete(BankPayment payment);
    }

}
