using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Address;

namespace Api.Domain.Interfaces.Services.Address
{
    public interface IAddressService
    {
        Task<AddressDtoObject> Get(Guid id);
        Task<AddressDtoObject> Get(string cep);
        Task<AddressDtoCreateResult> Post(AddressDtoCreate cep);
        Task<AddressDtoUpdateResult> Put(Guid id, AddressDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}