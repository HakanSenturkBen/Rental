using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal creditDal;

        public CreditCardManager(ICreditCardDal _creditDal)
        {
            creditDal = _creditDal;
        }

        public IResult Add(CreditCard card)
        {
            creditDal.Add(card);
            return new SuccessResult(card.Id.ToString());
        }

        public IResult Update(CreditCard card)
        {
            creditDal.Update(card);
            return new SuccessResult(Messages.Updated);
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IDataResult<CreditCard> GetCardByNumber(string card)
        {
            bool dene = ValidationRules.ValidationOthers.ValidCard(card);
            if (dene)
            {
                var result = new SuccessDataResult<CreditCard>(creditDal.Get(x => x.CardNumber == card));
                if (result.Data != null) return result;
                return new SuccessDataResult<CreditCard>("Kart numarası kredi kartları merkezinde kayıtlı değil");
            }
            return new ErrorDataResult<CreditCard>("Kart numarası geçerli bir numara değil ");
        }

        public IDataResult<CreditCard> GetCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(creditDal.Get(x => x.CustomerId == customerId));
        }

        public IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(creditDal.GetAll(x => x.CustomerId == customerId));
        }

    }
}