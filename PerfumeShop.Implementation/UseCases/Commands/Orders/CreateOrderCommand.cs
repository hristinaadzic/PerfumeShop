using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PerfumeShop.Application.Emails;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using PerfumeShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.Orders
{
    public class CreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private CreateOrderValidator _validator;
        public CreateOrderCommand(Context context, CreateOrderValidator validator) : base(context)
        {
            _validator = validator;  
        }

        public int Id => 14;

        public string Name => "Create new order";

        public string Description => "Creating new order using EF";

        public void Execute(CreateOrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = Context.User.Identity;

            var order = new Order
            {
                UserId = request.UserId,
                OrderLines = request.OrderLines.Select(x => new OrderLine
                {
                    ProductVolumeId = x.ProductVolumeId,
                    Quantity = x.Quantity,
                    Price = Context.Prices.Where(y => y.ProductVolumeId == y.ProductVolumeId && !y.IsDeleted)
                                      .Select(y => y.PriceValue).FirstOrDefault(),
                    ProductName = Context.ProductVolumes.Where(y => y.Id == x.ProductVolumeId)
                                                          .Select(y => y.Product).Select(y => y.Name).FirstOrDefault(),
                }).ToList(),
            };
            order.Total = order.OrderLines.Select(x => x.Price * x.Quantity).Sum();

            Context.Orders.Add(order);
            Context.OrderLines.AddRange(order.OrderLines);
            Context.SaveChanges();

        }
    }
}
