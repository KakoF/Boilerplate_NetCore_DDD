using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Email).HasMaxLength(100);
        }
    }
}