using System;

namespace Api.Domain.Dtos.State
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Iso { get; set; }
        public string Slug { get; set; }
    }
}