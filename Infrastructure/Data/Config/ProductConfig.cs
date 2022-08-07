using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.HasOne(x => x.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(x => x.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
    }
}