using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetCustomerById(int CustomerId);
        IDataResult<List<CustomerDto>> GetCustomerDtoAll();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetCustomerByUserId(int UserId);
        IDataResult<CustomerDto> GetCustomerDtoById(int customerId);
    }


}
