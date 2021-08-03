using System;
using System.Collections.Generic;

namespace Api.Domain.Models
{
  public class OrderItemModel : BaseModel
  {

    private int _quantity;
    public int Quantity
    {
      get { return _quantity; }
      set { _quantity = value; }
    }

    private string _name;
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }
    private Decimal _unityValue;
    public Decimal UnityValue
    {
      get { return _unityValue; }
      set { _unityValue = value; }
    }

    private int _itemId;
    public int ItemId
    {
      get { return _itemId; }
      set { _itemId = value; }
    }


    private int _orderId;
    public int OrderId
    {
      get { return _orderId; }
      set { _orderId = value; }
    }


  }
}