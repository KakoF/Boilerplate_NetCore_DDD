using System;
using Api.Domain.Entities;

namespace Api.Data.Seed
{
    public class UserSeed
    {
        public UserEntity Seed()
        {
            return new UserEntity
            {
                Id = 1,
                Name = "Kako",
                Email = "kakoferrare87@gmail.com",
                Password = "kako123456",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Role = "Admin"
            };
        }
    }
}