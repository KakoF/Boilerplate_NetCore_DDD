using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }


    }
}