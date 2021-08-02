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
    private readonly IDistributedCache _cache;
    DistributedCacheEntryOptions _opcoesCache;
    public StateService(IStateRepository repository, IMapper mapper, IUnitOfWork uof, IDistributedCache cache)
    {
      _uof = uof;
      _repository = repository;
      _mapper = mapper;
      _cache = cache;
      _opcoesCache = new DistributedCacheEntryOptions();
      _opcoesCache.SetAbsoluteExpiration(
          TimeSpan.FromHours(24));
    }


    public async Task<StateDto> Get(int id)
    {
      var entity = await _repository.SelectAsync(id);
      return _mapper.Map<StateDto>(entity) ?? new StateDto();
    }

    public async Task<IEnumerable<StateDto>> GetAll()
    {
      string cacheStates = _cache.GetString("AllStates");
      if (cacheStates == null)
      {
        var entityList = await _repository.GetAll();
        _cache.SetString("AllStates", JsonConvert.SerializeObject(entityList, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), _opcoesCache);
        return _mapper.Map<IEnumerable<StateDto>>(entityList);
      }
      return _mapper.Map<IEnumerable<StateDto>>(JsonConvert.DeserializeObject<IEnumerable<StateDto>>(cacheStates));

    }
    public async Task<IEnumerable<StateCityDto>> GetAllWithCity()
    {
      string cacheStatesWithCity = _cache.GetString("AllStatesWithCity");
      if (cacheStatesWithCity == null)
      {
        var entityList = await _repository.GetAllWithCity();
        _cache.SetString("AllStatesWithCity", JsonConvert.SerializeObject(entityList, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), _opcoesCache);
        return _mapper.Map<IEnumerable<StateCityDto>>(entityList);
      }
      return _mapper.Map<IEnumerable<StateCityDto>>(JsonConvert.DeserializeObject<IEnumerable<StateCityDto>>(cacheStatesWithCity));
    }

  }
}