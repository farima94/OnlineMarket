using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Infrastructure.Persistence.SqlServer.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.category).WithMany(p => p.products)
            .HasForeignKey(p=>p.CategoryId);
        builder.Property(p => p.Name).HasMaxLength(25).IsRequired();
        builder.Property(p => p.DiscountPercent).HasDefaultValue(0).IsRequired();
        builder.Property(p => p.DiscountPrice).IsRequired();
        builder.Property(p => p.MainPrice).IsRequired();


    }
}