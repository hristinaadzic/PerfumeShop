using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.DTO
{
    public class PriceDto : Dto
    {
        public int ProductVolumeId { get; set; }
        public decimal PriceValue { get; set; }
    }
}
