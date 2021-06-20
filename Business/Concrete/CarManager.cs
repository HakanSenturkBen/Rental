using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal carDal;

        public CarManager(ICarDal cardal)
        {
            carDal = cardal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Del(int carId)
        {
            Car car = carDal.Get(x => x.Id == carId);
            carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Delete(Car car)
        {
            carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarDto>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDto>>(carDal.GetCarsByBrand(brandId), Messages.Listed);
        }

        public IDataResult<List<CarDto>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(carDal.GetCarsByColor(colorId), Messages.Listed);
        }

        public IDataResult<CarDto> GetCarById(int carId)
        {
            return new SuccessDataResult<CarDto>(carDal.GetCarById(carId));
        }

        public IDataResult<Car> GetCarId(int carId)
        {
            return new SuccessDataResult<Car>(carDal.Get(x => x.Id == carId));
        }

        public IDataResult<List<CarDto>> GetCarInfo()
        {
            return new SuccessDataResult<List<CarDto>>(carDal.GetCarList());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
