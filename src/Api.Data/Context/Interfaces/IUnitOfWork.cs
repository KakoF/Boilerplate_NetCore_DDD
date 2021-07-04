namespace Api.Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commmit();
        void Rollback();

    }
}