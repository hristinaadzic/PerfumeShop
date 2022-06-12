using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class Price : Entity
    {
        public int ProductVolumeId { get; set; }
        public decimal PriceValue { get; set; }
        public ProductVolume ProductVolume { get; set; }
    }
}
