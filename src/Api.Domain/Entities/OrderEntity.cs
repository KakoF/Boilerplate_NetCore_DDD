using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
  public class OrderEntity : BaseEntity
  {
    public string NumberOrder { get; set; }

    public IEnumerable<OrderItemEntity> OrderItems { get; set; }

    public Decimal Total { get; set; }
  }
}