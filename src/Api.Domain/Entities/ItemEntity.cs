using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
  public class ItemEntity : BaseEntity
  {
    public string Name { get; set; }
    public Decimal Value { get; set; }

  }
}