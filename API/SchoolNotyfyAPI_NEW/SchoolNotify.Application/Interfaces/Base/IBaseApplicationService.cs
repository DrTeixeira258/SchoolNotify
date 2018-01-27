using System.Threading.Tasks;

namespace SchoolNotify.Application.Interfaces.Base
{
    public interface IBaseApplicationService
    {
        Task BeginTransaction();
        Task Commit();
    }
}
