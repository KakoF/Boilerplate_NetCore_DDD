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
                Password = "mk/If2RIa3xwA0IKFkf2fw==",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Role = "Admin"
            };
        }
    }
}