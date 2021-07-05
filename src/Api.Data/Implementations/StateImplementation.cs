using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.State;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class StateImplementation : BaseRepository<StateEntity>, IStateRepository
    {

        private DbSet<StateEntity> _dataset;
        public StateImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<StateEntity>();
        }

        public Task<List<StateEntity>> GetAll()
        {
            return _dataset.ToListAsync();
        }

        public Task<List<StateEntity>> GetAllWithCity()
        {
            //return _dataset.Include(c => c.City).ToListAsync();
            return _dataset.Include(c => c.City).ThenInclude(a => a.Address).ToListAsync();
        }
    }
}