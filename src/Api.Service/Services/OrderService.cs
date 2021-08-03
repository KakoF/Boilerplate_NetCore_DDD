using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context.Interfaces;
using Api.Domain.Dtos.Order;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Order;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
  public class OrderService : IOrderService
  {
    private readonly IRepository<OrderEntity> _repository;
    private readonly IRepository<ItemEntity> _itemRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public OrderService(IRepository<OrderEntity> repository, IRepository<ItemEntity> itemRepository, IMapper mapper, IUnitOfWork uof)
    {
      _uof = uof;
      _repository = repository;
      _itemRepository = itemRepository;
      _mapper = mapper;
    }

    public async Task<OrderDtoCreateResult> Post(OrderDtoCreate item)
    {
      try
      {

        var model = _mapper.Map<OrderModel>(item);
        //model.OrderItems.ToList().ForEach(n => n.UnityValue = _itemRepository.SelectAsync(n.Id).Result.Value);
        //  foreach (var it in model.OrderItems)
        foreach ((OrderItemModel it, Int32 i) in model.OrderItems.Select((value, i) => (value, i)))
        {
          var getItem = await _itemRepository.SelectAsync(it.ItemId);
          it.Name = getItem.Name;
          it.UnityValue = getItem.Value;

        }
        //model.OrderItems.ToList().ForEach(n => { n.UnityValue = 0; n.Name = "99"; } = _itemRepository.SelectAsync(n.Id).Result.Value);
        model.Total = model.OrderItems.Sum(x => x.Quantity * x.UnityValue);
        var entity = _mapper.Map<OrderEntity>(model);
        var result = await _repository.InsertAsync(entity);
        _uof.Commmit();
        return _mapper.Map<OrderDtoCreateResult>(result);
      }
      catch (System.Exception e)
      {
        throw e;
      }

    }
  }
}