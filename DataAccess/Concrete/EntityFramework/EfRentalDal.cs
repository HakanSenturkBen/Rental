using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalContext>, IRentalDal
    {
        public List<RentalDto> GetRentalsDto()
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from rental in contex.Rentals
                             join customer in contex.Customer on rental.CustomerId equals customer.Id
                             join user in contex.User on customer.UserId equals user.Id
                             join car in contex.Cars on rental.CarId equals car.Id
                             join brand in contex.Brands on car.BrandId equals brand.Id
                             select new RentalDto
                             {
                                 RentalId = rental.Id,
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }

        public List<RentalDto> GetRentalsDto(int carId)
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from rental in contex.Rentals
                             join customer in contex.Customer on rental.CustomerId equals customer.Id
                             join user in contex.User on customer.UserId equals user.Id
                             join car in contex.Cars on rental.CarId equals car.Id
                             join brand in contex.Brands on car.BrandId equals brand.Id
                             where car.Id == carId
                             select new RentalDto
                             {
                                 RentalId = rental.Id,
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.OrderByDescending(x => x.ReturnDate).ToList();
            }
        }
    }
}