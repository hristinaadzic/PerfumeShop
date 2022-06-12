using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Queries.Brands
{
    public class GetOneBrandQuery : EfUseCase, IGetOneBrandQuery
    {
        public GetOneBrandQuery(Context context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Get one brand";

        public string Description => "Get brand by id";

        public BrandDto Execute(int request)
        {
            var brand = Context.Brands.Where(x => !x.IsDeleted).AsQueryable().FirstOrDefault(x => x.Id == request);

            if(brand == null)
            {
                throw new EntityNotFoundException(nameof(Brand), request);
            }

            return new BrandDto
            {
                id = brand.Id,
                Name = brand.Name
            };
        }
    }
}
