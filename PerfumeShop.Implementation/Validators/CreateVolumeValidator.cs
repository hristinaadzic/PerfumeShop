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
    public class CreateVolumeValidator : AbstractValidator<VolumeDto>
    {
        private Context _context;
        public CreateVolumeValidator(Context context)
        {

            _context = context;

            RuleFor(x => x.Volume).Cascade(CascadeMode.Stop)
                                   .ExclusiveBetween(1,1000).WithMessage("Volume needs to be in range 1-1000")
                                   .Must(x => !context.Volumes.Any(v => v.VolumeInMillilitres == x)).WithMessage("Volume {Propertyvalue} is already in use");
        }
    }
}
