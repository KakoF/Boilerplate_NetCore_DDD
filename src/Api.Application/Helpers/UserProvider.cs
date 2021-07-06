using System;
using System.Linq;
using System.Security.Claims;
using Api.Application.Helpers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Api.Application.Helpers
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context;
        }

        public User User()
        {
            User user = new User();
            user.Id = Convert.ToInt32(_context.HttpContext.User.Claims.First().Value);
            return user;
        }
    }

    public class User
    {
        public int Id;
    }
}