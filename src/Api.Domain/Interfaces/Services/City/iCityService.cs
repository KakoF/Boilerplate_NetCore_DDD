using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;

namespace Api.Domain.Interfaces.Services.County
{
    public interface iCityService
    {
        Task<CityDto> Get(int id);
        Task<CityDto> GetByIBGE(string iso);
        Task<IEnumerable<CityDto>> GetAll();

    }
}