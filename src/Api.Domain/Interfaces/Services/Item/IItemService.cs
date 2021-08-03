using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Item;
using Api.Domain.Dtos.Order;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Item
{
  public interface IItemService
  {
    Task<ItemDtoResult> Get(int id);
  }
}