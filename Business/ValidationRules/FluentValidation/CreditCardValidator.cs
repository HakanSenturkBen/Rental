using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(card => card.CardNumber).Must(ValidNumber).WithMessage("Kart numarası gerçek bir numara değil");
            RuleFor(x => x.CardHolderName).MinimumLength(6);
            RuleFor(x => x.CardHolderName).MaximumLength(50);
            RuleFor(x => x.Cvv).MinimumLength(3);
            RuleFor(x => x.Cvv).MaximumLength(3);
            RuleFor(x => x.CardNumber).MinimumLength(16);
            RuleFor(x => x.CardNumber).MaximumLength(16);
            RuleFor(x => x.CardHolderName).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ(ğ) harfi ile başlayamaz");
        }

        private bool ValidNumber(string arg)
        {
            return ValidationOthers.ValidCard(arg);
        }
        private bool StartWithA(string arg)
        {
            if (arg.StartsWith("Ğ") || arg.StartsWith("ğ"))
            {
                return false;
            }
            return true;
        }
    }
}
