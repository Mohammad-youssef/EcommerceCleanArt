using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p=> p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p=> p.Description).IsRequired().HasMaxLength(256);
            builder.Property(p=> p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p=> p.PictureUrl).IsRequired();
            builder.HasOne(p=> p.ProductBrand).WithMany().
                HasForeignKey(P=> P.ProductBrandId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p=> p.ProductType).WithMany().
                HasForeignKey(P=> P.ProductTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
