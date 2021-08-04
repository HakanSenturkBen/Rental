using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BankPaymentValidator : AbstractValidator<BankPayment>
    {
        public BankPaymentValidator()
        {
            RuleFor(x => x.CreditCardNumber).MinimumLength(16);
            RuleFor(x => x.CreditCardNumber).MaximumLength(16);
        }

    }
}