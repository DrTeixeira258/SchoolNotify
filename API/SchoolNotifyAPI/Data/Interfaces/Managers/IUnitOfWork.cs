namespace Data.Interfaces.Managers
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
