using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
        }
        private bool CantBigger(string arg)
        {
            if (arg.StartsWith("Ğ") || arg.StartsWith("ğ"))
            {
                return false;
            }
            return true;
        }
    }
}