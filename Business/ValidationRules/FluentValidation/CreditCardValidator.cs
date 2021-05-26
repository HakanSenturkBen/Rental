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
        }

        private bool ValidNumber(string arg)
        {
            return ValidationOthers.ValidCard(arg);
        }
    }
}
