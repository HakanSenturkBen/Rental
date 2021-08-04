using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.ColorName).MinimumLength(2);
            RuleFor(x => x.ColorName).MaximumLength(50);
            RuleFor(x => x.ColorName).Must(StartWithA).WithMessage("Türkçe'de sözcükler Ğ(ğ) harfi ile başlayamaz");
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