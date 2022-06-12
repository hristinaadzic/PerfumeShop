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
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(x => x.OrderId).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ProductVolumeId).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Quantity).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Price).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(30);
        }
    }
}
