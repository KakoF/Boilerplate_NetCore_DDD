using System;
using System.Collections.Generic;
using Api.Domain.Dtos.OrderItem;

namespace Api.Domain.Dtos.Order
{
  public class OrderDtoCreateResult
  {
    public int Id { get; set; }
    public string NumberOrder { get; set; }
    public IEnumerable<OrderItemDtoCreateResult> OrderItems { get; set; }
    public Decimal Total { get; set; }

  }
}