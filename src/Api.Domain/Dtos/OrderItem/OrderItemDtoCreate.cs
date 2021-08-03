using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.OrderItem
{
  public class OrderItemDtoCreate
  {
    [Required(ErrorMessage = "Item é obrigatório.")]
    public int ItemId { get; set; }

    [Required(ErrorMessage = "Quantidade é obrigatória.")]
    [Range(1, Int32.MaxValue, ErrorMessage = "Deve ter no minimo {1} item.")]
    public int Quantity { get; set; }

  }
}