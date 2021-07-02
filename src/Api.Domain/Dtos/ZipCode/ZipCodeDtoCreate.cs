using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.ZipCode
{
    public class ZipCodeDtoCreate
    {
        [Required(ErrorMessage = "CEP é campo obrigatório")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Logradouro é campo obrigatório")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bairro é campo obrigatório")]
        public string District { get; set; }
        public string Number { get; set; }

        [Required(ErrorMessage = "Município é campo obrigatório")]
        public Guid CountyId { get; set; }
    }
}