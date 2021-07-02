using System;
using Api.Domain.Dtos.City;

namespace Api.Domain.Dtos.Address
{
    public class AddressDtoObject
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }
        public CityDtoObject City { get; set; }
    }
}