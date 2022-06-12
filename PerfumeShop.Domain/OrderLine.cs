using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class OrderLine : Entity
    {
        public int OrderId { get; set; }
        public int ProductVolumeId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public ProductVolume ProductVolume { get; set; }
    }
}
