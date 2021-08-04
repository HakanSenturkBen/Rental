using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;
        public CustomerManager(ICustomerDal _customerDal)
        {
            customerDal = _customerDal;
        }

        public IResult Add(Customer customer)
        {
            customerDal.Add(customer);
            return new SuccessResult(customer.Id.ToString());
        }

        public IResult Delete(Customer customer)
        {
            customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll());
        }

        public IDataResult<Customer> GetCustomerById(int CustomerId)
        {
            return new SuccessDataResult<Customer>(customerDal.Get(x => x.Id == CustomerId));
        }

        public IDataResult<Customer> GetCustomerByUserId(int UserId)
        {
            return new SuccessDataResult<Customer>(customerDal.Get(x => x.UserId == UserId));
        }

        public IDataResult<List<CustomerDto>> GetCustomerDtoAll()
        {
            return new SuccessDataResult<List<CustomerDto>>(customerDal.GetCustomerList());
        }

        public IDataResult<CustomerDto> GetCustomerDtoById(int customerId)
        {
            return new SuccessDataResult<CustomerDto>(customerDal.GetCustomerDto(customerId));
        }

        public IResult Update(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
