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

namespace PerfumeShop.Implementation.UseCases.Commands.Prices
{
    public class CreatePriceCommand : EfUseCase, ICreatePriceCommand
    {
        private CreatePriceValidator _validator;
        public CreatePriceCommand(Context context, CreatePriceValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Create price";

        public string Description => "Creating price for product and his specific volume";

        public void Execute(PriceDto request)
        {
            _validator.ValidateAndThrow(request);

            var price = new Price
            {
                PriceValue = request.PriceValue,
                ProductVolumeId = request.ProductVolumeId
            };

            Context.Prices.Add(price);
            Context.SaveChanges();
        }
    }
}
