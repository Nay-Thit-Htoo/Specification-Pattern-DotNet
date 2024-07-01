using CommonSpecificationPattern;
using Specification.Model;
using System.Linq.Expressions;

namespace Specification.UserSpecification
{
    public class NameSpecification : Specification<User>
    {
        private readonly string _name;

        public NameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Name == _name;
        }
    }
}
