using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.DTO
{
    public class OrderDto : Dto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }

    public class CreateOrderDto : Dto
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }       
        public ICollection<CreateOrderLineDto> OrderLines { get; set; } = new List<CreateOrderLineDto>();
    }
}
