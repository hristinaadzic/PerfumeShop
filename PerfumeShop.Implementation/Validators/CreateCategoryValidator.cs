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
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private Context _context;

        public CreateCategoryValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name is required")
                                .MinimumLength(3).WithMessage("Category name requires minimum 3 characters")
                                .Must(CategoryNotInUse).WithMessage("Category {PropertyValue} already exist");
        }

        private bool CategoryNotInUse(string name)
        {
            var exists = _context.Categories.Any(x => x.Name == name);

            return !exists;
        }
    }
}
