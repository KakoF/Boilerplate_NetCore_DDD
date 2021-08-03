
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.OrderItem
{
  public class OrderItemDtoCreateResult
  {
    public int Quantity { get; set; }
    public string Name { get; set; }
    public Decimal UnityValue { get; set; }

  }
}
