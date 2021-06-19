using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;

        public RentalManager(IRentalDal _rentalDal)
        {
            rentalDal = _rentalDal;
        }

        public IResult Add(Rental rental)
        {

            rentalDal.Add(rental);
            return new SuccessResult(rental.Id.ToString());


        }

        public IResult Delete(Rental rental)
        {
            rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int Id)
        {
            return new SuccessDataResult<Rental>(rentalDal.Get(x => x.CarId == Id));
        }

        public IDataResult<List<RentalDto>> GetRentalsDto(int carId)
        {
            var result = new SuccessDataResult<List<RentalDto>>(rentalDal.GetRentalsDto(carId));
            if (result.Data.Count > 0)
                if (DateTime.Compare(result.Data[0].ReturnDate, DateTime.Now) > 0 || DateTime.Compare(result.Data[0].ReturnDate, DateTime.Now) == 0)
                {
                    return new ErrorDataResult<List<RentalDto>>("Araç " + result.Data[0].ReturnDate.ToShortDateString() + " tarihine kadar  başka bir üyemize kiralanmıştır.");
                }
            return new SuccessDataResult<List<RentalDto>>(result.Data, Messages.avaible);
        }

        public IResult Update(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }

}

