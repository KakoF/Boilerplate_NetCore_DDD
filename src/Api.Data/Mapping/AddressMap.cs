using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("Adresses");
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.ZipCode).HasMaxLength(8);
            builder.Property(u => u.Address).IsRequired().HasMaxLength(250);
            builder.Property(u => u.District).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Number).IsRequired().HasMaxLength(10);
            builder.Property(u => u.CityId);
        }
    }
}