using Api.Domain.Dtos;
using Api.Domain.Dtos.Address;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.Order;
using Api.Domain.Dtos.OrderItem;
using Api.Domain.Dtos.Register;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
  public class EntityToDtoProfile : Profile
  {
    public EntityToDtoProfile()
    {
      CreateMap<UserDto, UserEntity>().ReverseMap();
      CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
      CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
      CreateMap<RegisterResponseDto, UserEntity>().ReverseMap();
      CreateMap<LoginResponseDto, UserEntity>().ReverseMap();
      CreateMap<StateDto, StateEntity>().ReverseMap();
      CreateMap<StateCityDto, StateEntity>().ReverseMap();
      CreateMap<CityDto, CityEntity>().ReverseMap();
      CreateMap<AddressDtoObject, AddressEntity>().ReverseMap();
      CreateMap<OrderEntity, OrderDtoCreateResult>().ReverseMap();
      CreateMap<OrderItemEntity, OrderItemDtoCreateResult>().ReverseMap();
    }
  }
}