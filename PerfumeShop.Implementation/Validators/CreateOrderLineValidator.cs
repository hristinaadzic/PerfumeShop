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
    public class CreateOrderLineValidator : AbstractValidator<CreateOrderLineDto>
    {
        private Context _context;

        public CreateOrderLineValidator(Context context)
        {
            _context = context;

            RuleFor(x => x.ProductVolume).Cascade(CascadeMode.Stop)
                                         .NotEmpty().WithMessage("ProductVolumeId can not be empty");
        }


    }
}
