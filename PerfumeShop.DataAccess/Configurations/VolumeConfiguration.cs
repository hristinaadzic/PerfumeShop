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
    public class VolumeConfiguration : IEntityTypeConfiguration<Volume>
    {
        public void Configure(EntityTypeBuilder<Volume> builder)
        {
            builder.Property(x => x.VolumeInMillilitres).IsRequired().HasMaxLength(5);

            builder.HasMany(x => x.ProductVolumes)
                    .WithOne(x => x.Volume)
                    .HasForeignKey(x => x.VolumeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
