using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class BankPaymentManager : IBankPaymentService
    {
        IBankPaymentDal paymentDal;

        public BankPaymentManager(IBankPaymentDal _paymentDal)
        {
            paymentDal = _paymentDal;
        }

        public IResult Add(BankPayment payment)
        {
            paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }


        public IResult Delete(BankPayment payment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<BankPayment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<BankPayment> GetPaymentById(int paymentId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(BankPayment payment)
        {
            throw new NotImplementedException();
        }
    }
}