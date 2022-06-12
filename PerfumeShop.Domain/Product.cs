using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int GenderId { get; set; }
        public int BrandId { get; set; }
        public Gender Gender { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductVolume> ProductVolumes { get; set; }
    }
}
