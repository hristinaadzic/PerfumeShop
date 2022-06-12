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
    public class CreatePriceValidator : AbstractValidator<PriceDto>
    {
        private Context _context;
        public CreatePriceValidator(Context context)
        {
            _context = context;

            RuleFor(x => x.PriceValue).NotEmpty().WithMessage("Price is required")
                                      .ScalePrecision(2, 8).WithMessage("Price is in decimal value in 8,2 format");

            RuleFor(x => x.ProductVolumeId).NotEmpty().WithMessage("ProductVolumeIs is required")
                                            .Must(x => _context.ProductVolumes.Any(y => y.Id == x && !y.IsDeleted))
                                            .WithMessage("ProductVolume doesn't exist");
        }
    }
}
