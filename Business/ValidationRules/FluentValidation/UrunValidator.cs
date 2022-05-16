using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UrunValidator:AbstractValidator<Urun>
    {
        public UrunValidator()
        {
            RuleFor(u => u.UrunAdi).MinimumLength(2);
            RuleFor(u => u.UrunAdi).NotEmpty();
            RuleFor(u => u.Fiyat).GreaterThan(0);
        }
    }
 }
