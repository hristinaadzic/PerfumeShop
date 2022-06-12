using FluentValidation;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using PerfumeShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.Volumes
{
    public class CreateVolumeCommand : EfUseCase, ICreateVolumeCommand
    {
        CreateVolumeValidator _validator;
        public CreateVolumeCommand(Context context, CreateVolumeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Create new volume";

        public string Description => "Creating new volume using EF";

        public void Execute(VolumeDto request)
        {
            _validator.ValidateAndThrow(request);

            var volume = new Volume
            {
                VolumeInMillilitres = request.Volume
            };

            Context.Volumes.Add(volume);
            Context.SaveChanges();
        }
    }
}
