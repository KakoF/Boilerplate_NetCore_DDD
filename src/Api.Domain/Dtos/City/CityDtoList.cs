using System;
using Api.Domain.Dtos.State;

namespace Api.Domain.Dtos.City
{
    public class CityDtoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Slug { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public Guid StateId { get; set; }
        public StateDto State { get; set; }
    }
}