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

namespace PerfumeShop.Implementation.UseCases.Commands.Orders
{
    public class SoftDeleteOrderCommand : EfUseCase, ISoftDeleteOrderCommand
    {
        public SoftDeleteOrderCommand(Context context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Soft delete order";

        public string Description => "Updating idDeleted column";

        public void Execute(OrderDto request)
        {
            var id = request.id;

            var order = Context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new EntityNotFoundException(nameof(Order), request);
            }

            order.IsDeleted = true;
            order.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
