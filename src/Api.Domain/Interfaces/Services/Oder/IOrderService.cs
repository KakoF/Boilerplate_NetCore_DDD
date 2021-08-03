using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Order;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Order
{
  public interface IOrderService
  {
    Task<OrderDtoCreateResult> Post(OrderDtoCreate item);
  }
}