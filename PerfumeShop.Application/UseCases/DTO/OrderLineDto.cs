using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.DTO
{
    public class OrderLineDto : Dto
    {
        public string ProductName { get; set; }
        public IEnumerable<PriceDto> Price { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderLineDto : Dto
    {
        public int ProductVolumeId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceForOne { get; set; }
        public IEnumerable<ProductVolume> ProductVolume { get; set; }
    }
}
