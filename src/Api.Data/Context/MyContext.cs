using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<StateEntity>(new StateMap().Configure);
            modelBuilder.Entity<CountyEntity>(new CountyMap().Configure);
            modelBuilder.Entity<AddressEntity>(new AddressMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Kako",
                    Email = "kakoferrare87@gmail.com",
                    Password = "kako123456",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                }
            );
        }
    }
}