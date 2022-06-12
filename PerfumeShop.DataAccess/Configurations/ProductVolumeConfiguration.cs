using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.DataAccess.Configurations
{
    public class ProductVolumeConfiguration : IEntityTypeConfiguration<ProductVolume>
    {
        public void Configure(EntityTypeBuilder<ProductVolume> builder)
        {

            builder.HasMany(x => x.Price)
                    .WithOne(x => x.ProductVolume)
                    .HasForeignKey(x => x.ProductVolumeId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderLines)
                    .WithOne(x => x.ProductVolume)
                    .HasForeignKey(x => x.ProductVolumeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
