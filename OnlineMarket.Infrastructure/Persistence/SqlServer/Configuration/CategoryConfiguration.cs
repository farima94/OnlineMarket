using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Infrastructure.Persistence.SqlServer.Configuration;


public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
   
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ImageUrl).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
        builder.Property(p => p.Description).IsRequired();
    }
}