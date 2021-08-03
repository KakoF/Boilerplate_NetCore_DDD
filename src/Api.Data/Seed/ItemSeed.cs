using System;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Data.Seed
{
  public class ItemSeed
  {
    public List<ItemEntity> Seed()
    {
      List<ItemEntity> list = new List<ItemEntity>(){
                new ItemEntity
                {
                    Id = 1,
                    Name = "Item 1",
                    Value = 55.35M,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new ItemEntity
                {
                    Id = 2,
                    Name = "Item 2",
                    Value = 10.50M,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },

            };
      return list;
    }
  }
}