using System;
using System.Collections.Generic;
using System.Linq;
using Api.Data.Mapping;
using Api.Data.Seed;
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
      //modelBuilder.HasSequence<int>("Seq_user").StartsAt(1).IncrementsBy(1);
      modelBuilder.Entity<UserEntity>(new UserMap().Configure);
      modelBuilder.Entity<StateEntity>(new StateMap().Configure);
      modelBuilder.Entity<CityEntity>(new CityMap().Configure);
      modelBuilder.Entity<AddressEntity>(new AddressMap().Configure);
      modelBuilder.Entity<ItemEntity>(new ItemMap().Configure);
      modelBuilder.Entity<OrderEntity>(new OrderMap().Configure);
      modelBuilder.Entity<OrderItemEntity>(new OrderItemMap().Configure);

      modelBuilder.Entity<UserEntity>().HasData(new UserSeed().Seed());
      List<StateEntity> seedState = new StateSeed().Seed();
      List<CityEntity> seedCity = new CitySeed().Seed();
      foreach (var item in seedState)
      {
        modelBuilder.Entity<StateEntity>().HasData(item);
      }
      foreach (var item in seedCity)
      {
        modelBuilder.Entity<CityEntity>().HasData(item);
      }
      //modelBuilder.Entity<UserEntity>().Property(o => o.Id).HasDefaultValueSql("NEXT VALUE FOR dbo.Seq_user");
    }
  }
}