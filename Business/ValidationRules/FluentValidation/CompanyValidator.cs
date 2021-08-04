using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName).MinimumLength(2);
            RuleFor(x => x.CompanyName).MaximumLength(100);
            RuleFor(x => x.CoPhoneNumber).MaximumLength(18);
            RuleFor(x => x.CoPhoneNumber).MinimumLength(2);
            RuleFor(x => x.TaxNumber).MinimumLength(10);
            RuleFor(x => x.TaxNumber).MaximumLength(10);
            RuleFor(x => x.TaxOfficeName).MaximumLength(50);
            RuleFor(x => x.TaxOfficeName).MinimumLength(10);
            RuleFor(x => x.TaxOfficeName).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ(ğ) harfi ile başlayamaz");
            RuleFor(x => x.CompanyName).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ(ğ) harfi ile başlayamaz");
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