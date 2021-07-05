using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Address;
using Api.Domain.Dtos.State;

namespace Api.Domain.Dtos.City
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Slug { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public int StateId { get; set; }
        public StateDto State { get; set; }
        public IEnumerable<AddressDtoObject> Address { get; set; }
    }
}