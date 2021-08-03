using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Domain.Models
{
  public class OrderModel : BaseModel
  {
    private string _numberOrder;
    public string NumberOrder
    {
      get { return _numberOrder; }
      set { _numberOrder = value; }
    }

    private IEnumerable<OrderItemModel> _orderItems;
    public IEnumerable<OrderItemModel> OrderItems
    {
      get { return _orderItems; }
      set { _orderItems = value; }
    }

    private Decimal _total;
    public Decimal Total
    {
      get { return _total; }
      //set { _total = _orderItems.Sum(x => x.Quantity * x.UnityValue); }
      set { _total = value; }
    }
  }
}