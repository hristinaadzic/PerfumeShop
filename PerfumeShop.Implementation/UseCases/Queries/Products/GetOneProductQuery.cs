using Microsoft.EntityFrameworkCore;
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

namespace PerfumeShop.Implementation.UseCases.Queries.Products
{
    public class GetOneProductQuery : EfUseCase, IGetOneProductQuery
    {
        public GetOneProductQuery(Context context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Get one product";

        public string Description => "Get product by id";

        public ProductDto Execute(int request)
        {
            var product = Context.Products.Where(x => !x.IsDeleted)
                                .Include(x => x.ProductCategories)
                                .ThenInclude(x => x.Category).Where(x => !x.IsDeleted)
                                .Include(x => x.Brand).Where(x => !x.IsDeleted)
                                .Include(x => x.Gender)
                                .Include(x => x.ProductVolumes).ThenInclude(x => x.Volume)
                                .Include(x => x.ProductVolumes)
                                .ThenInclude(x => x.Price).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request);
            }

            return new ProductDto
            {
                id = product.Id,
                Name = product.Name,
                ImagePath = product.ImagePath,
                Description = product.Description,
                Brand = product.Brand.Name,
                Gender = product.Gender.GenderName,
                Categories = product.ProductCategories.Select(y => new CategoryDto
                {
                    id = y.Category.Id,
                    Name = y.Category.Name
                }),
                Volume = product.ProductVolumes.Select(z => new VolumeDto
                {
                    id = z.Id,
                    Volume = z.Volume.VolumeInMillilitres,
                    Price = z.Price.Select(a => new PriceDto
                    {
                        id = a.Id,
                        PriceValue = a.PriceValue
                    })
                })
            };
        }
    }
}
