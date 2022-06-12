using FluentValidation;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.Validators
{
    public class CreateBrandValidator : AbstractValidator<BrandDto>
    {
        private Context _context;

        public CreateBrandValidator(Context context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name is required")
                                .MinimumLength(3).WithMessage("Brand name requires minimum 3 characters")
                                .Must(BrandNotInUse).WithMessage("Brand {PropertyValue} already exist");
            _context = context;
        }

        private bool BrandNotInUse(string name)
        {
            var exists = _context.Brands.Any(x => x.Name == name);

            return !exists;
        }
    }
}
