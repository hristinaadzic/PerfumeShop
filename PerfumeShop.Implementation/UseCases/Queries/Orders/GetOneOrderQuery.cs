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

namespace PerfumeShop.Implementation.UseCases.Queries.Orders
{
    public class GetOneOrderQuery : EfUseCase, IGetOneOrderQuery
    {
        public GetOneOrderQuery(Context context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Get one order";

        public string Description => "Get order by id";

        public OrderDto Execute(int request)
        {
            var order = Context.Orders.Include(x => x.OrderLines)
                                       .ThenInclude(x => x.ProductVolume).ThenInclude(x => x.Product)
                                       .ThenInclude(x => x.ProductVolumes).ThenInclude(x => x.Price)
                                       .Include(x => x.User).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (order == null)
            {
                throw new EntityNotFoundException(nameof(Order), request);
            }

            return new OrderDto
            {
                id = order.Id,
                OrderLines = order.OrderLines.Select(y => new OrderLineDto
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
                Total = order.Total
            };
        }
    }
}
