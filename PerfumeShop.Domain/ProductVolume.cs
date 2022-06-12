using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class ProductVolume : Entity
    {
        public int ProductId { get; set; }
        public int VolumeId { get; set; }
        public Product Product { get; set; }
        public Volume Volume { get; set; }
        public ICollection<Price> Price{ get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
