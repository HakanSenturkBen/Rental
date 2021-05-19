using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<CarDto> GetCarById(int carId);
        IDataResult<List<CarDto>> GetByColorId(int colorId);
        IDataResult<List<CarDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDto>> GetCarInfo();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
