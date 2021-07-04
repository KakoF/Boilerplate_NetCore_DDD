using Api.Data.Context.Interfaces;

namespace Api.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        public UnitOfWork(MyContext context)
        {
            _context = context;
        }
        /*public void Begin()
        {
            _context.Database.BeginTransaction();
        }*/
        public void Commmit()
        {

            _context.SaveChanges();
            //_context.Database.CommitTransaction();
        }

        /*public void Rollback()
        {
            _context.Database.RollbackTransaction();
            _context.Dispose();
        }*/
    }
}