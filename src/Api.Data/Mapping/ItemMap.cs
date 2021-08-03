using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class ItemMap : IEntityTypeConfiguration<ItemEntity>
  {
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
      builder.ToTable("Items");
      builder.Property(u => u.Id).ValueGeneratedOnAdd();
      builder.Property(u => u.Name).IsRequired();
      builder.Property(u => u.Value).IsRequired();
    }
  }
}