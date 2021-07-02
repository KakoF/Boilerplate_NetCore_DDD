using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class StateEntity : BaseEntity
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2)]
        public string Initials { get; set; }
        public string Iso { get; set; }
        public string Slug { get; set; }


        public IEnumerable<CityEntity> City { get; set; }
    }
}