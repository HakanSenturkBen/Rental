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
        IAddressDal addressDal;
        ICompanyDal companyDal;
        IAuthService authService;

        public CustomerManager(ICustomerDal _customerDal)
        {
            customerDal = _customerDal;
        }

        public CustomerManager(ICustomerDal _customerDal, IAddressDal _address, ICompanyDal _company, IAuthService _authService)
        {
            customerDal = _customerDal;
            addressDal = _address;
            companyDal = _company;
            authService = _authService;

        }

        public IResult Add(CustomerDto customer)
        {
            UserForRegisterDto user = new UserForRegisterDto
            {
                Email = customer.Email,
                FirstName = customer.Name,
                LastName = customer.Name,
                Password = customer.Password
            };

            var registerResult = authService.Register(user, user.Password);

            Address address = new Address
            {
                Address1 = customer.Address,
                Address2 = customer.Address,
                City = customer.City,
                State = customer.State
            };
            addressDal.Add(address);

            Company company = new Company
            {
                AddressId = address.Id,
                CompanyName = customer.CompanyName,
                CoPhoneNumber = customer.CoPhoneNumber,
                TaxNumber = customer.TaxNumber,
                TaxOfficeName = customer.TaxOfficeName
            };
            companyDal.Add(company);
            Customer _customer = new Customer
            {
                UserId = registerResult.Data.Id,
                AddressId = address.Id,
                CompanyId = company.Id,
                CitizenShipNumber = customer.CitizenShipNumber,
                PhoneNumber = customer.PhoneNumber,
            };
            customerDal.Add(_customer);
            return new SuccessResult(Messages.Added);
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

        public IDataResult<List<CustomerDto>> GetCustomerDtoAll()
        {
            return new SuccessDataResult<List<CustomerDto>>(customerDal.GetCustomerList());
        }

        public IResult Update(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
