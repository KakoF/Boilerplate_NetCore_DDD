using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class AddressEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        [Required]
        [MaxLength(60)]
        public string District { get; set; }

        [MaxLength(10)]
        public string Number { get; set; }

        [Required]
        public int CityId { get; set; }

        public CityEntity City { get; set; }
    }
}