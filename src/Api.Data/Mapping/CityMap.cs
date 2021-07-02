using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);
            builder.Property(u => u.Iso).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Slug).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Lat);
            builder.Property(u => u.Long);
            builder.Property(u => u.StateId);
        }
    }
}