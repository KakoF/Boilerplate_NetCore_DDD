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
            //builder.Property(u => u.Id).ValueGeneratedOnAdd().HasAnnotation("IDENTITY", "(1,1)");
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(60);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Role).IsRequired().HasDefaultValue("Guest");
        }
    }
}