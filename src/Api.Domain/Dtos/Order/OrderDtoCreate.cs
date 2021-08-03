using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.OrderItem;

namespace Api.Domain.Dtos.Order
{
  public class OrderDtoCreate
  {
    [Required(ErrorMessage = "Itens são obrigatórios.")]
    [MinLength(1, ErrorMessage = "Deve ter no minimo {1} item.")]
    public IEnumerable<OrderItemDtoCreate> OrderItems { get; set; }

  }
}