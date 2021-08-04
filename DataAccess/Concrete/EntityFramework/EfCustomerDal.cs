using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
using Business;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalContext>, ICustomerDal
    {
        public CustomerDto GetCustomerDto(int customerId)
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from customer in contex.Customer
                             join address in contex.Address
                             on customer.AddressId equals address.Id
                             join company in contex.Company
                             on customer.CompanyId equals company.Id
                             join user in contex.User
                             on customer.UserId equals user.Id
                             where customer.Id == customerId
                             select new CustomerDto
                             {
                                 CustomerId = customer.Id,
                                 UserId = customer.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = customer.PhoneNumber,
                                 Password = customer.Password,
                                 CitizenShipNumber = customer.CitizenShipNumber,
                                 CompanyId = customer.CompanyId,
                                 CompanyName = company.CompanyName,
                                 TaxOfficeName = company.TaxOfficeName,
                                 TaxNumber = company.TaxNumber,
                                 CoPhoneNumber = company.CoPhoneNumber,
                                 AddressId = customer.AddressId,
                                 Address1 = address.Address1,
                                 Address2 = address.Address2,
                                 City = address.City,
                                 State = address.State,
                             };
                return result.SingleOrDefault();
            }
        }


        public List<CustomerDto> GetCustomerList()
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from customer in contex.Customer
                             join address in contex.Address
                             on customer.AddressId equals address.Id
                             join company in contex.Company
                             on customer.CompanyId equals company.Id
                             join user in contex.User
                             on customer.UserId equals user.Id
                             select new CustomerDto
                             {
                                 CustomerId = customer.Id,
                                 UserId = customer.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = customer.PhoneNumber,
                                 Password = customer.Password,
                                 CitizenShipNumber = customer.CitizenShipNumber,
                                 CompanyId = customer.CompanyId,
                                 CompanyName = company.CompanyName,
                                 TaxOfficeName = company.TaxOfficeName,
                                 TaxNumber = company.TaxNumber,
                                 CoPhoneNumber = company.CoPhoneNumber,
                                 AddressId = customer.AddressId,
                                 Address1 = address.Address1,
                                 Address2 = address.Address2,
                                 City = address.City,
                                 State = address.State,
                             };

                return result.OrderBy(x => x.FirstName).ToList();

            }
        }

       
    }
}
