
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Item
{
  public class ItemDtoResult
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public Decimal Value { get; set; }

  }
}
