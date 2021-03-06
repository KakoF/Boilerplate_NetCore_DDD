using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Slug { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        [Required]
        public int StateId { get; set; }
        public StateEntity State { get; set; }

        public IEnumerable<AddressEntity> Address { get; set; }


    }
}