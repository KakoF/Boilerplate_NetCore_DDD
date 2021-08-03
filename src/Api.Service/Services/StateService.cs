using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context.Interfaces;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.State;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Interfaces.Utils;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Api.Service.Services
{
  public class StateService : IStateService
  {
    private readonly IStateRepository _repository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    private readonly IRedis _cache;
    DistributedCacheEntryOptions _opcoesCache;
    public StateService(IStateRepository repository, IMapper mapper, IUnitOfWork uof, IRedis cache)
    {
      _uof = uof;
      _repository = repository;
      _mapper = mapper;
      _cache = cache;
    }


    public async Task<StateDto> Get(int id)
    {
      var entity = await _repository.SelectAsync(id);
      return _mapper.Map<StateDto>(entity) ?? new StateDto();
    }

    public async Task<IEnumerable<StateDto>> GetAll()
    {
      IEnumerable<StateDto> cacheStates = await _cache.GetListAsync<StateDto>("AllStates");
      if (cacheStates == null)
      {
        var entityList = await _repository.GetAll();
        _cache.SetList("AllStates", entityList);
        return _mapper.Map<IEnumerable<StateDto>>(entityList);
      }
      return _mapper.Map<IEnumerable<StateDto>>(cacheStates);

    }
    public async Task<IEnumerable<StateCityDto>> GetAllWithCity()
    {
      IEnumerable<StateDto> cacheStatesWithCity = await _cache.GetListAsync<StateDto>("AllStatesWithCity");
      if (cacheStatesWithCity == null)
      {
        var entityList = await _repository.GetAllWithCity();
        _cache.SetList("AllStatesWithCity", cacheStatesWithCity);
        return _mapper.Map<IEnumerable<StateCityDto>>(entityList);
      }
      return _mapper.Map<IEnumerable<StateCityDto>>(cacheStatesWithCity);
    }

  }
}