using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Utils
{
  public interface IRedis
  {
    Task<T> GetAsync<T>(string key);
    Task<IEnumerable<T>> GetListAsync<T>(string key);
    void Set(string key, object value, int expirationMinutes = 1);
    void SetList(string key, IEnumerable<object> value, int expirationMinutes = 1);
    void Remove(string key);
  }
}