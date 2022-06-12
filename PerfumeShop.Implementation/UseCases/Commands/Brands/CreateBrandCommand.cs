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

namespace PerfumeShop.Implementation.UseCases.Commands.Brands
{
    public class CreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        private CreateBrandValidator _validator;

        public CreateBrandCommand(Context context, CreateBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Create new brand";

        public string Description => "Creating new brand using EF";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = new Brand
            {
                Name = request.Name
            };

            Context.Brands.Add(brand);
            Context.SaveChanges();
        }
    }
}
