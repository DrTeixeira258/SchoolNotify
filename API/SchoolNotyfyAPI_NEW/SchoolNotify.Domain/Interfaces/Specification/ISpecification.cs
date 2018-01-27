
namespace SchoolNotify.Domain.Interfaces.Specification
{
    public interface ISpecification<T> where T : class
    {
        bool IsSatisfiedBy(T entity);
    }
}
