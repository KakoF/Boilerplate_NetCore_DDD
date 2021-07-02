using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;

namespace Api.Domain.Interfaces.Services.ZipCode
{
    public interface IZipCodeService
    {
        Task<ZipCodeDtoObject> Get(Guid id);
        Task<ZipCodeDtoObject> Get(string cep);
        Task<ZipCodeDtoCreateResult> Post(ZipCodeDtoCreate cep);
        Task<ZipCodeDtoUpdateResult> Put(Guid id, ZipCodeDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}