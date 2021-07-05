using System;
using System.Collections.Generic;
using Api.Domain.Dtos.City;

namespace Api.Domain.Dtos.State
{
    public class StateCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Iso { get; set; }
        public string Slug { get; set; }
        public IEnumerable<CityDto> City { get; set; }
    }
}