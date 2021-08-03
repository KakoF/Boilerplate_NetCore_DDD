using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
  public class OrderItemEntity : BaseEntity
  {
    public int Quantity { get; set; }
    public string Name { get; set; }
    public Decimal UnityValue { get; set; }
    public int ItemId { get; set; }
    public ItemEntity Item { get; set; }
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; }

  }
}