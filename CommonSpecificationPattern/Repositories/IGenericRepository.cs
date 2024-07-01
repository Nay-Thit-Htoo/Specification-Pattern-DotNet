using CommonSpecificationPattern;

namespace Specification.Services
{
    public interface IGenericRepository<T> where T : class
    {    
        IEnumerable<T> Find(ISpecification<T> specification);
    }
}
