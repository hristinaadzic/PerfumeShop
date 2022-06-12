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
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        private Context _context;

        public CreateOrderValidator(Context context)
        {
            _context = context;

            //RuleFor(x => x.ProductVolumeId).NotEmpty().WithMessage("ProductVolumeId can not be emty");

            RuleFor(x => x.UserId).NotEmpty().WithMessage("User can not be empty");
        }
    }
}
