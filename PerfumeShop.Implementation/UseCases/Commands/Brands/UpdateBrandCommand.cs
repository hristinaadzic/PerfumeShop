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
    public class UpdateBrandCommand : EfUseCase, IUpdateBrandCommand
    {
        public UpdateBrandCommand(Context context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Update brand";

        public string Description => "Updating specific brand";

        public void Execute(BrandDto request)
        {
            var id = request.id;
            var name = request.Name;

            var brand = Context.Brands.FirstOrDefault(x => x.Id == id);

            if(brand == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception();
            }

            brand.Name = name;
            Context.SaveChanges();
        }
    }
}
