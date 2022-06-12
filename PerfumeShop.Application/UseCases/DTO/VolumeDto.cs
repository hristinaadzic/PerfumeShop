using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.DTO
{
    public class VolumeDto : Dto
    {
        public int Volume { get; set; }
        public IEnumerable<PriceDto> Price { get; set; }
    }
}
