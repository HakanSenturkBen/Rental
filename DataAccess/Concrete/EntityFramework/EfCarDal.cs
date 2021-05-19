using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Business;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {


        public List<CarDto> GetCarList()
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from car in contex.Cars
                             join brand in contex.Brands
                             on car.BrandId equals brand.Id
                             join color in contex.Colors
                             on car.ColorId equals color.Id
                             select new CarDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear
                             };
                return result.OrderBy(x => x.BrandName).ToList();
            }
        }

        public List<CarDto> GetCarsByBrand(int brandId)
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from car in contex.Cars
                             join brand in contex.Brands
                             on car.BrandId equals brand.Id
                             join color in contex.Colors
                             on car.ColorId equals color.Id
                             where car.BrandId == brandId
                             select new CarDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear
                             };
                return result.OrderBy(x => x.BrandName).ToList();
            }
        }
        public List<CarDto> GetCarsByColor(int colorId)
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from car in contex.Cars
                             join brand in contex.Brands
                             on car.BrandId equals brand.Id
                             join color in contex.Colors
                             on car.ColorId equals color.Id
                             where car.ColorId == colorId
                             select new CarDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear
                             };
                return result.OrderBy(x => x.BrandName).ToList();
            }
        }

        public CarDto GetCarById(int Id)
        {
            using (RentalContext contex = new RentalContext())
            {
                var result = from car in contex.Cars
                             join brand in contex.Brands
                             on car.BrandId equals brand.Id
                             join color in contex.Colors
                             on car.ColorId equals color.Id
                             where car.Id == Id
                             select new CarDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
