using Microsoft.EntityFrameworkCore;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Queries.Products
{
    public class GetProductsQuery : EfUseCase, IGetProductsQuery
    {
        public GetProductsQuery(Context context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Searching products";

        public string Description => "Searching products using EF";

        public IEnumerable<ProductDto> Execute(BaseSearch request)
        {
            var query = Context.Products.Where(x => !x.IsDeleted)
                                .Include(x => x.ProductCategories)
                                .ThenInclude(x => x.Category).Where(x => !x.IsDeleted)
                                .Include(x => x.Brand).Where(x => !x.IsDeleted)
                                .Include(x => x.Gender)
                                .Include(x => x.ProductVolumes).ThenInclude(x => x.Volume)
                                .Include(x => x.ProductVolumes)
                                .ThenInclude(x => x.Price).AsQueryable();
                                
                                

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword) ||
                                         x.Description.Contains(request.Keyword) ||
                                         x.ProductCategories.Any(x => x.Category.Name.Contains(request.Keyword)) ||
                                         x.Brand.Name.Contains(request.Keyword));
                                
            }

            return query.Select(x => new ProductDto
            {
                id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                Description = x.Description,
                Brand = x.Brand.Name,
                Gender = x.Gender.GenderName,
                Categories = x.ProductCategories.Select(y => new CategoryDto
                {
                    id = y.Category.Id,
                    Name = y.Category.Name
                }),
                Volume = x.ProductVolumes.Select(z => new VolumeDto
                {
                    id = z.Id,
                    Volume = z.Volume.VolumeInMillilitres,
                    Price = z.Price.Select(a => new PriceDto
                    {
                         id = a.Id,
                         PriceValue = a.PriceValue
                    })
                })
            }).ToList();
        }
    }
}
