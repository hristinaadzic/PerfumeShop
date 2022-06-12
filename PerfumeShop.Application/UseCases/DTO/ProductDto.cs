using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.DTO
{
    public class ProductDto : Dto
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Brand { get; set; }
        public IEnumerable<VolumeDto> Volume { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }

    public class CreateProductDto : Dto
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int GenderId { get; set; }
        public int BrandId { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] VolumeIds { get; set; }
    }

}
