using Business.Abstract;
using Business.ValidationRules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        [ValidationAspect(typeof(CreditCardValidator))]
        public IDataResult<CreditCard> GetCardByNumber(string card)
        {
            bool dene = ValidationRules.ValidationOthers.ValidCard(card);
            if (dene)
            {
                var result = new SuccessDataResult<CreditCard>(creditDal.Get(x => x.CardNumber == card));
                if (result.Data != null) return result;
                return new ErrorDataResult<CreditCard>("Kart numarası kredi kartları merkezinde kayıtlı değil");
            }
            return new ErrorDataResult<CreditCard>("Kart numarası geçerli bir numara değil ");
        }

    }
}