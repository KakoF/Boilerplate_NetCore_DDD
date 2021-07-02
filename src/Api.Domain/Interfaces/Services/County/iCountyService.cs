using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;

namespace Api.Domain.Interfaces.Services.County
{
    public interface iCountyService
    {
        Task<CountyDtoObject> Get(Guid id);
        Task<CountyDtoObject> GetByIBGE(int IBGE);
        Task<IEnumerable<CountyDtoList>> GetAll();

    }
}