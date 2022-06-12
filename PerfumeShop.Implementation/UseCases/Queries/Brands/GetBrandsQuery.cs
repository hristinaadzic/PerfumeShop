using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Queries.Brands
{
    public class GetBrandsQuery : EfUseCase, IGetBrandsQuery
    {
        public GetBrandsQuery(Context context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Search brands";

        public string Description => "Searching brands uding EF";

        public IEnumerable<BrandDto> Execute(BaseSearch request)
        {
            var query = Context.Brands.Where(x => !x.IsDeleted).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            return query.Select(x => new BrandDto
            {
                id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
