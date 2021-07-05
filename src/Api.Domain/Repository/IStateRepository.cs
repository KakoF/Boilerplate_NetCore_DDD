using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IStateRepository : IRepository<StateEntity>
    {
        Task<List<StateEntity>> GetAll();
        Task<List<StateEntity>> GetAllWithCity();
    }
}