using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class KategoriValidator : AbstractValidator<Kategori>
    {
        public KategoriValidator()
        {
            RuleFor(k=>k.KategoriAdi).MinimumLength(2).NotEmpty();
        }
    }
}
