using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;

namespace Api.Domain.Interfaces.Services.County
{
    public interface iCityService
    {
        Task<CityDtoObject> Get(int id);
        Task<CityDtoObject> GetByIBGE(string iso);
        Task<IEnumerable<CityDtoList>> GetAll();

    }
}