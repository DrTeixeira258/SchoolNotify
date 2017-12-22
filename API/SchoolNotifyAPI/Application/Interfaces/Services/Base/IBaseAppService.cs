namespace Application.Interfaces.Services.Base
{
    public interface IBaseAppService
    {
        void BeginTransaction();
        void Commit();
    }
}
