using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.ImagePath).Must(StartWithA).WithMessage(" 'Yerleşik path ./assets' kalıbıyla başlamalıdır");
        }
        private bool StartWithA(string arg)
        {
            if (arg.StartsWith("./assets"))
            {
                return true;
            }
            return false;
        }
    }
}