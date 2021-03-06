using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Utils;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Api.Service.Utils
{
  public class Redis : IRedis
  {
    IDistributedCache _redisCache;
    public Redis(IDistributedCache distributedCache)
    {
      _redisCache = distributedCache;
    }
    public async Task<T> GetAsync<T>(string key)
    {
      var json = await _redisCache.GetStringAsync(key);
      return (json == null) ? default(T) : JsonConvert.DeserializeObject<T>(json);
    }
    public void Set(string key, object value, int expirationMinutes = 1)
    {
      DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
      opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(expirationMinutes));

      var json = JsonConvert.SerializeObject(value);
      _redisCache.SetStringAsync(key, json, opcoesCache);
    }
    public void Remove(string key)
    {
      _redisCache.RemoveAsync(key);
    }

    public async Task<IEnumerable<T>> GetListAsync<T>(string key)
    {
      var json = await _redisCache.GetStringAsync(key);
      return (json == null) ? default(IEnumerable<T>) : JsonConvert.DeserializeObject<IEnumerable<T>>(json);
    }

    public void SetList(string key, IEnumerable<object> value, int expirationMinutes = 1)
    {
      DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
      opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(expirationMinutes));

      var json = JsonConvert.SerializeObject(value);
      _redisCache.SetStringAsync(key, json, opcoesCache);
    }
  }
}
