using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Register
{
    public class RegisterResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}