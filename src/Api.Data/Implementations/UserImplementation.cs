using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {

        private DbSet<UserEntity> _dataset;
        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public UserEntity GetUserByEmail(string email) => _dataset.FirstOrDefault(u => u.Email.Equals(email));

        public async Task<UserEntity> Login(string email, string password)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
        }
    }
}