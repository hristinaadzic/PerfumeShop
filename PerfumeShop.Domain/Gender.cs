using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class Gender : Entity
    {
        public string GenderName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
