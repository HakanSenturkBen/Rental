using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Address1).MinimumLength(2);
            RuleFor(x => x.City).MinimumLength(3);
            RuleFor(x => x.City).MaximumLength(20);
            RuleFor(x => x.State).MaximumLength(20);
            RuleFor(x => x.State).MinimumLength(3);
            RuleFor(x => x.City).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ harfi ile başlayamaz");
            RuleFor(x => x.State).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ harfi ile başlayamaz");
            RuleFor(x => x.Address1).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ harfi ile başlayamaz");
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