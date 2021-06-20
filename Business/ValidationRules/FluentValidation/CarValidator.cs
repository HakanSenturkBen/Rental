
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThan(1500);
            RuleFor(p => p.DailyPrice).LessThan(7500);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(5);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}

