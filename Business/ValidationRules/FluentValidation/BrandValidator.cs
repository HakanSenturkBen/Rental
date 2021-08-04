using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).MinimumLength(2);
            RuleFor(x => x.BrandName).MaximumLength(50);
            RuleFor(x => x.BrandName).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ harfi ile başlayamaz");
        }
        private bool StartWithA(string arg)
        {
            if (arg.StartsWith("Ğ")|| arg.StartsWith("ğ"))
            {
                return false;
            }
            return true;
        }
    }
}