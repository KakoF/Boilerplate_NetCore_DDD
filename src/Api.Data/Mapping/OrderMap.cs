using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class OrderMap : IEntityTypeConfiguration<OrderEntity>
  {
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
      builder.ToTable("Orders");
      builder.Property(u => u.Id).ValueGeneratedOnAdd();
      builder.Property(u => u.NumberOrder).HasMaxLength(8);
      builder.Property(u => u.Total).IsRequired();
    }
  }
}