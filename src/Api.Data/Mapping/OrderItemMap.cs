using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class OrderItemMap : IEntityTypeConfiguration<OrderItemEntity>
  {
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
      builder.ToTable("OrderItems");
      builder.Property(u => u.Id).ValueGeneratedOnAdd();
      builder.Property(u => u.Quantity).IsRequired();
      builder.Property(u => u.Name).IsRequired();
      builder.Property(u => u.UnityValue).IsRequired();
      builder.Property(u => u.ItemId).IsRequired();
      builder.Property(u => u.OrderId).IsRequired();
    }
  }
}