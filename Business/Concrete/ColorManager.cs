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
    public class ColorManager : IColorService
    {
        IColorDal colorDal;

        public ColorManager(IColorDal _colorDal)
        {
            colorDal = _colorDal;
        }

        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExists(color.ColorName));
            if (result != null)
            {
                return result;
            }
            colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        private IResult CheckIfColorNameExists(string colorName)
        {
            var result = colorDal.GetAll(x => x.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(colorDal.GetAll());
        }

        public IDataResult<Color> GetColorById(int colorId)
        {
            return new SuccessDataResult<Color>(colorDal.Get(x => x.Id == colorId));
        }

        public IResult Update(Color color)
        {
            colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}

