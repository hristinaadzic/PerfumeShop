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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(x => x.GenderName).IsRequired().HasMaxLength(15);
            builder.HasIndex(x => x.GenderName);

            builder.HasMany(x => x.Products)
                    .WithOne(x => x.Gender)
                    .HasForeignKey(x => x.GenderId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
