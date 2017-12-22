using System.Data.Entity;

namespace Data.Interfaces.Managers
{
    public interface IContextManager
    {
        DbContext GetContext();
    }
}
