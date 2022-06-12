using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public User User { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
