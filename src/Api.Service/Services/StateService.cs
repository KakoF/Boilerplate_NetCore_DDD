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

namespace Api.Service.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _repository;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public StateService(IStateRepository repository, IMapper mapper, IUnitOfWork uof)
        {
            _uof = uof;
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<StateDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<StateDto>(entity) ?? new StateDto();
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            var entityList = await _repository.GetAll();
            return _mapper.Map<IEnumerable<StateDto>>(entityList);
        }
        public async Task<IEnumerable<StateCityDto>> GetAllWithCity()
        {
            var entityList = await _repository.GetAllWithCity();
            return _mapper.Map<IEnumerable<StateCityDto>>(entityList);
        }

    }
}