using System;

namespace Api.Domain.Dtos.Address
{
    public class AddressDtoCreateResult
    {

        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public int CityId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}