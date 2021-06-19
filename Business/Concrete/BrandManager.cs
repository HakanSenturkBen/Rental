using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal _brandDal)
        {
            brandDal = _brandDal;
        }

        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));
            if (result != null)
            {
                return result;
            }
            brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        private IResult CheckIfBrandNameExists(string brandName)
        {
            var result = brandDal.GetAll(x => x.BrandName == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }
            return new SuccessResult(); throw new NotImplementedException();
        }

        public IResult Delete(Brand brand)
        {
            brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(brandDal.GetAll());
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            return new SuccessDataResult<Brand>(brandDal.Get(x => x.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));
            if (result != null)
            {
                return result;
            }
            brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}