using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CountyMap : IEntityTypeConfiguration<CountyEntity>
    {
        public void Configure(EntityTypeBuilder<CountyEntity> builder)
        {
            builder.ToTable("Counties");
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