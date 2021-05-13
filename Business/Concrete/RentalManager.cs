using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            var result = GetByCarId(rental.CarId);
            if (result.Data == null || rental.ReturnDate != null)
            {
                rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.Added);
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

        public IDataResult<List<RentalDto>> GetRentalsDto()
        {
            return new SuccessDataResult<List<RentalDto>>(rentalDal.GetRentalsDto());
        }

        public IResult Update(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }

}

