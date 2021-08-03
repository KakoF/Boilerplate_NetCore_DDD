using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context.Interfaces;
using Api.Domain.Dtos.Item;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Item;
using Api.Domain.Interfaces.Services.Order;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
  public class ItemService : IItemService
  {
    private readonly IRepository<ItemEntity> _repository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public ItemService(IRepository<ItemEntity> repository, IMapper mapper, IUnitOfWork uof)
    {
      _uof = uof;
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ItemDtoResult> Get(int id)
    {
      try
      {
        var entity = await _repository.SelectAsync(id);
        return _mapper.Map<ItemDtoResult>(entity) ?? new ItemDtoResult();
      }
      catch (System.Exception e)
      {
        throw e;
      }

    }
  }
}