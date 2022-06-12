﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.ProductCategories)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
