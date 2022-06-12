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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.GenderId).IsRequired().HasMaxLength(10);
            builder.Property(x => x.BrandId).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.ProductCategories)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ProductVolumes)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
