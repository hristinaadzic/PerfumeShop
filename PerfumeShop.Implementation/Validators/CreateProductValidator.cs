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
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        private Context _context;
        public CreateProductValidator(Context context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty().WithMessage("Name is required")
                                .MinimumLength(3).WithMessage("Name must contain at least 3 charachters");

            RuleFor(x => x.BrandId).Cascade(CascadeMode.Stop)
                                       .NotEmpty().WithMessage("BrandId is required")
                                       .Must(x => _context.Brands.Any(y => y.Id == x && !y.IsDeleted)).WithMessage("Provided brand id doesn't exist");

            RuleFor(x => x.GenderId).Cascade(CascadeMode.Stop)
                                        .NotEmpty().WithMessage("GenderId is required")
                                        .Must(x => _context.Genders.Any(y => y.Id == x)).WithMessage("GenderId doesn't exist");

            RuleFor(x => x.CategoryIds).Cascade(CascadeMode.Stop)
                                        .NotEmpty().WithMessage("CategoryId is required")
                                        .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed")
                                        .DependentRules(() =>
                                        {
                                            RuleForEach(x => x.CategoryIds).Must(x => _context.Categories.Any(y => y.Id == x && !y.IsDeleted)).WithMessage("CategoryId doesn't exist");
                                        });
            RuleFor(x => x.VolumeIds).Cascade(CascadeMode.Stop)
                                        .NotEmpty().WithMessage("VolumeId is required")
                                        .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed")
                                        .DependentRules(() =>
                                        {
                                            RuleForEach(x => x.VolumeIds).Must(x => _context.Volumes.Any(y => y.Id == x && !y.IsDeleted)).WithMessage("CategoryId doesn't exist");
                                        });

            RuleFor(x => x.ImagePath).Cascade(CascadeMode.Stop)
                                     .MinimumLength(5).WithMessage("Image must contain at least 5 charachetrs")
                                     .MaximumLength(150).WithMessage("Image can contain to 150 charachters");
                                     

                                       
                              
        }

    }
}
