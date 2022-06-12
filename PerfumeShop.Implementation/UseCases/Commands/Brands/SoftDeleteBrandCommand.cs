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

namespace PerfumeShop.Implementation.UseCases.Commands.Brands
{
    public class SoftDeleteBrandCommand : EfUseCase, ISoftDeleteBrandCommand
    {
        public SoftDeleteBrandCommand(Context context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Soft delete brand";

        public string Description => "Updating isDelete column";

        public void Execute(BrandDto request)
        {
            var id = request.id;

            var brand = Context.Brands.FirstOrDefault(x => x.Id == id);

            if (brand == null)
            {
                throw new EntityNotFoundException(nameof(Brand), request);
            }

            brand.IsDeleted = true;
            brand.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
