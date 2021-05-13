using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal imageService;

        public CarImageManager(ICarImageDal imageService)
        {
            this.imageService = imageService;
        }

        public IResult Add(CarImage carImage)
        {
            var result = imageService.GetAll(x => x.CarId == carImage.CarId);
            if (result.Count < 5)
            {
                imageService.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult("Sayı sınırına ulaşıldı");
        }

        public IResult Delete(CarImage carImage)
        {
            imageService.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(imageService.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImageById(int CarId)
        {
            var result = new SuccessDataResult<List<CarImage>>(imageService.GetAll(x => x.CarId == CarId));
            if (result.Data.Count != 0)
            {
                return result;
            }
            result.Data.Add(new CarImage { Id = 0, CarId = CarId, ImagePath = "Default.jpg", Date = DateTime.Now });
            return result;


        }

        public IResult Update(CarImage carImage)
        {
            imageService.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }
    }
}

