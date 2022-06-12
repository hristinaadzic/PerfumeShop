using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain
{
    public class Volume : Entity
    {
        public int VolumeInMillilitres { get; set; }
        public ICollection<ProductVolume> ProductVolumes { get; set; }
    }
}
