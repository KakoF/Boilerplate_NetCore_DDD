using System;
using System.Collections.Generic;

namespace Api.Domain.Models
{
  public class ItemModel : BaseModel
  {

    private string _name;
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }
    private Decimal _value;
    public Decimal Value
    {
      get { return _value; }
      set { _value = value; }
    }
  }
}