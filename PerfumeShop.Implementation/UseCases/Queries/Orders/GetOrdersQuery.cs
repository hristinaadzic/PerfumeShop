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

namespace PerfumeShop.Implementation.UseCases.Queries.Orders
{
    public class GetOrdersQuery : EfUseCase, IGetOrdersQuery
    {
        public GetOrdersQuery(Context context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Search orders";

        public string Description => "Searching orders using EF";

        public IEnumerable<OrderDto> Execute(BaseSearch request)
        {
            var query = Context.Orders.Include(x => x.OrderLines)
                                       .ThenInclude(x => x.ProductVolume).ThenInclude(x => x.Product)
                                       .ThenInclude(x => x.ProductVolumes).ThenInclude(x => x.Price)
                                       .Include(x => x.User).AsQueryable();

            return query.Select(x => new OrderDto
            {
                id = x.Id,
                OrderLines = x.OrderLines.Select(y => new OrderLineDto
                {
                    id = y.Id,
                     Quantity = y.Quantity,
                     Price = y.ProductVolume.Price.Select(a => new PriceDto
                     {
                         PriceValue = a.PriceValue,
                         id = a.Id
                         
                     }),
                     ProductName = y.ProductVolume.Product.Name
                }),
                Total = x.Total
            }).ToList();
                                    
        }
    }
}
