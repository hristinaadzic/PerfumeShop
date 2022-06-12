using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.DTO
{
    public class ProductVolumeDto : Dto
    {
        public IEnumerable<ProductDto> Product { get; set; }
        public IEnumerable<VolumeDto> Volume { get; set; }
    }
}
