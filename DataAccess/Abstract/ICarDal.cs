using Business;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDto> GetCarList();
        List<CarDto> GetCarsByBrand(int brandId);
        List<CarDto> GetCarsByColor(int colorId);
        CarDto GetCarById(int Id);
    }
}
