using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.Prices
{
    public class SoftDeletePriceCommand : EfUseCase, ISoftDeletePriceCommand
    {
        public SoftDeletePriceCommand(Context context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Soft delete price";

        public string Description => "Updating isDeleted column";

        public void Execute(PriceDto request)
        {
            var id = request.id;

            var price = Context.Products.FirstOrDefault(x => x.Id == id);

            if (price == null)
            {
                throw new EntityNotFoundException(nameof(Price), request);
            }

            price.IsDeleted = true;
            price.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
