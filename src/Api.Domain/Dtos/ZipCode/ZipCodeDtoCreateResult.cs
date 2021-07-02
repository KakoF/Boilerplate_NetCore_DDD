using System;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoCreateResult
    {

        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public Guid CountyId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}