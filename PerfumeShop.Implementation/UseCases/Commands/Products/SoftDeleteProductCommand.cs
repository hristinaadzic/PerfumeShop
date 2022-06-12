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

namespace PerfumeShop.Implementation.UseCases.Commands.Products
{
    public class SoftDeleteProductCommand : EfUseCase, ISoftDeleteProductCommand
    {
        public SoftDeleteProductCommand(Context context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Soft delete product";

        public string Description => "Updating idDeleted product";

        public void Execute(ProductDto request)
        {
            var id = request.id;

            var product = Context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request);
            }

            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
