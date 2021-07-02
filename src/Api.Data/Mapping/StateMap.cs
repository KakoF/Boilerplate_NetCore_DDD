using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class StateMap : IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            builder.ToTable("States");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Initials).IsRequired().HasMaxLength(2);
            builder.Property(u => u.Iso).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Slug).HasMaxLength(100);
        }
    }
}